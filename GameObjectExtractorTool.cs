using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text;

public class GameObjectExtractorTool : EditorWindow
{
    private List<GameObject> allSceneObjects = new List<GameObject>();
    private Vector2 scrollPosition;
    private bool includeInactive = true;
    private string searchFilter = "";
    private bool includeComponents = true;
    private bool includeTransformInfo = true;
    private GUIStyle italicStyle;

    [MenuItem("Tools/Exporter GameObjects en TXT")]
    public static void ShowWindow()
    {
        GetWindow<GameObjectExtractorTool>("Exporter GameObjects en TXT");
    }

    private void OnEnable()
    {
        // Créer un style italique
        italicStyle = new GUIStyle(EditorStyles.label);
        italicStyle.fontStyle = FontStyle.Italic;
    }

    private void OnGUI()
    {
        // Initialiser le style italique s'il n'existe pas
        if (italicStyle == null)
        {
            italicStyle = new GUIStyle(EditorStyles.label);
            italicStyle.fontStyle = FontStyle.Italic;
        }

        GUILayout.Label("Exporter tous les GameObjects en TXT", EditorStyles.boldLabel);

        EditorGUILayout.Space();

        // Options d'extraction
        includeInactive = EditorGUILayout.Toggle("Inclure objets inactifs", includeInactive);
        includeComponents = EditorGUILayout.Toggle("Inclure composants", includeComponents);
        includeTransformInfo = EditorGUILayout.Toggle("Inclure info Transform", includeTransformInfo);

        // Bouton d'extraction
        if (GUILayout.Button("EXTRAIRE TOUS LES OBJETS", GUILayout.Height(30)))
        {
            ExtractAllGameObjects();
        }

        // Barre de recherche
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Filtrer:", GUILayout.Width(50));
        searchFilter = EditorGUILayout.TextField(searchFilter);
        EditorGUILayout.EndHorizontal();

        // Nombre d'objets
        EditorGUILayout.Space();
        int filteredCount = GetFilteredCount();
        EditorGUILayout.LabelField($"Objets: {filteredCount} filtrés / {allSceneObjects.Count} total");

        // Prévisualisation
        scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true));

        if (allSceneObjects.Count > 0)
        {
            EditorGUILayout.LabelField("Prévisualisation:", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            int displayed = 0;
            foreach (GameObject obj in allSceneObjects)
            {
                // Appliquer le filtre
                if (!string.IsNullOrEmpty(searchFilter) && !obj.name.ToLower().Contains(searchFilter.ToLower()))
                    continue;

                // Limiter la prévisualisation à 20 objets
                if (displayed >= 20)
                {
                    EditorGUILayout.LabelField("...(et plus)...", italicStyle);
                    break;
                }

                string prefix = obj.activeInHierarchy ? "● " : "○ ";
                EditorGUILayout.LabelField(prefix + GetGameObjectPath(obj), EditorStyles.label);
                displayed++;
            }
        }

        EditorGUILayout.EndScrollView();

        // Boutons d'exportation
        EditorGUILayout.Space();

        if (GUILayout.Button("EXPORTER VERS TXT", GUILayout.Height(30)))
        {
            ExportToTextFile();
        }
    }

    private int GetFilteredCount()
    {
        if (string.IsNullOrEmpty(searchFilter))
            return allSceneObjects.Count;

        int count = 0;
        foreach (GameObject obj in allSceneObjects)
        {
            if (obj.name.ToLower().Contains(searchFilter.ToLower()))
                count++;
        }
        return count;
    }

    private void ExtractAllGameObjects()
    {
        allSceneObjects.Clear();

        // Récupérer tous les objets racines
        GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

        // Ajouter tous les objets (racines et enfants récursivement)
        foreach (GameObject root in rootObjects)
        {
            // Ajouter chaque objet racine
            allSceneObjects.Add(root);

            // Ajouter tous les enfants de l'objet racine
            Transform[] allChildren = root.GetComponentsInChildren<Transform>(includeInactive);
            foreach (Transform child in allChildren)
            {
                // Ne pas ajouter l'objet racine deux fois
                if (child.gameObject != root)
                {
                    allSceneObjects.Add(child.gameObject);
                }
            }
        }

        // Trier par hiérarchie
        allSceneObjects.Sort((a, b) => GetGameObjectPath(a).CompareTo(GetGameObjectPath(b)));

        Debug.Log($"Extrait {allSceneObjects.Count} GameObjects de la scène");
    }

    private void ExportToTextFile()
    {
        if (allSceneObjects.Count == 0)
        {
            EditorUtility.DisplayDialog("Aucun objet", "Veuillez d'abord extraire les objets de la scène.", "OK");
            return;
        }

        // Demander où sauvegarder le fichier
        string sceneName = SceneManager.GetActiveScene().name;
        if (string.IsNullOrEmpty(sceneName)) sceneName = "UntitledScene";

        string path = EditorUtility.SaveFilePanel(
            "Sauvegarder la liste d'objets",
            "",
            sceneName + "_GameObjects.txt",
            "txt"
        );

        if (string.IsNullOrEmpty(path)) return;

        // Créer le contenu du fichier
        StringBuilder sb = new StringBuilder();

        // En-tête
        sb.AppendLine("======================================================");
        sb.AppendLine($"LISTE DES GAMEOBJECTS - SCÈNE: {sceneName}");
        sb.AppendLine($"Date: {System.DateTime.Now}");
        sb.AppendLine($"Nombre total d'objets: {allSceneObjects.Count}");
        if (!string.IsNullOrEmpty(searchFilter))
            sb.AppendLine($"Filtre appliqué: '{searchFilter}'");
        sb.AppendLine("======================================================");
        sb.AppendLine();

        // Liste des objets
        int count = 0;
        foreach (GameObject obj in allSceneObjects)
        {
            // Appliquer le filtre si nécessaire
            if (!string.IsNullOrEmpty(searchFilter) && !obj.name.ToLower().Contains(searchFilter.ToLower()))
                continue;

            count++;
            string status = obj.activeInHierarchy ? "ACTIF" : "inactif";
            sb.AppendLine($"[{count}] {GetGameObjectPath(obj)} ({status})");

            // Informations sur la position
            if (includeTransformInfo)
            {
                sb.AppendLine($"    Position: {obj.transform.position}");
                sb.AppendLine($"    Rotation: {obj.transform.rotation.eulerAngles}");
                sb.AppendLine($"    Échelle: {obj.transform.localScale}");
            }

            // Informations sur les composants
            if (includeComponents)
            {
                Component[] components = obj.GetComponents<Component>();
                sb.AppendLine($"    Composants ({components.Length}):");
                foreach (Component comp in components)
                {
                    if (comp != null)
                        sb.AppendLine($"      - {comp.GetType().Name}");
                }
            }

            sb.AppendLine();
        }

        // Pied de page
        sb.AppendLine("======================================================");
        sb.AppendLine($"FIN DE LA LISTE - {count} OBJETS EXPORTÉS");
        sb.AppendLine("======================================================");

        // Écrire le fichier
        try
        {
            File.WriteAllText(path, sb.ToString());
            Debug.Log($"Liste d'objets exportée vers: {path}");

            // Ouvrir automatiquement le fichier
            if (EditorUtility.DisplayDialog("Export réussi",
                $"La liste de {count} objets a été exportée vers:\n{path}\n\nVoulez-vous ouvrir ce fichier maintenant?",
                "Ouvrir", "Non"))
            {
                Application.OpenURL("file://" + path);
            }
        }
        catch (System.Exception ex)
        {
            EditorUtility.DisplayDialog("Erreur d'exportation",
                $"Une erreur s'est produite lors de l'exportation:\n{ex.Message}", "OK");
        }
    }

    // Obtient le chemin complet d'un GameObject
    private string GetGameObjectPath(GameObject obj)
    {
        if (obj == null) return "";

        string path = obj.name;
        Transform parent = obj.transform.parent;

        while (parent != null)
        {
            path = parent.name + "/" + path;
            parent = parent.parent;
        }

        return path;
    }
}