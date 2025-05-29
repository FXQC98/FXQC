⭐ Générateur de Heightmap - Workers & Resources: Soviet Republic
Un générateur de cartes topographiques haute précision pour créer des heightmaps personnalisées dans Workers & Resources: Soviet Republic.

🎯 Fonctionnalités
🌍 Données Géographiques Réelles

Utilise l'API Mapbox pour récupérer des données topographiques authentiques
Sélection interactive de zones de 20x20 km partout dans le monde
Configuration automatique des paramètres selon le terrain analysé
Précision jusqu'à 1.2m/pixel (zoom niveau 18)

🎲 Génération Procédurale

6 types de terrains prédéfinis : Montagnes, Collines, Plaines, Côtes, Vallées, Plateaux
Algorithme de bruit de Perlin avancé avec seed personnalisable
Génération déterministe (même seed = même résultat)
Aucune API requise pour ce mode

🔬 Haute Précision

Résolutions : 2K, 4K, 8K, 16K (jusqu'à 16384×16384 pixels)
Interpolation : Bilinéaire, Bicubique, Lanczos
Format : PNG noir et blanc optimisé pour W&R:SR
Lissage : 4 niveaux de post-traitement

🚀 Installation & Utilisation
📋 Prérequis

Navigateur web moderne (Chrome, Firefox, Safari, Edge)
Connexion internet pour les données géographiques réelles
Clé API Mapbox (gratuite) pour les données réelles

🔑 Configuration de la clé API Mapbox

Créer un compte Mapbox :

Allez sur mapbox.com
Créez un compte gratuit
Confirmez votre email


Obtenir votre clé API :

Connectez-vous à votre compte Mapbox
Allez dans "Access tokens"
Copiez votre "Default public token" (commence par pk.)


Configurer l'outil :

Ouvrez le générateur de heightmap
Collez votre clé dans le champ "Clé API Mapbox"
Cliquez sur "💾 Sauvegarder la clé"
Testez avec "🔍 Tester la clé"




⚠️ Important : Votre clé API est stockée localement dans votre navigateur et n'est jamais partagée.

📖 Guide d'utilisation
Mode Données Réelles :

Configurez votre clé API Mapbox
Cliquez sur "🚀 Charger la carte Mapbox"
Naviguez vers la zone désirée (ou utilisez la recherche)
Cliquez et glissez sur la carte pour sélectionner une zone
Ajustez les paramètres si nécessaire
Cliquez "⚡ Générer carte topographique"
Téléchargez avec "⭐ Exporter heightmap socialiste"

Mode Procédural :

Sélectionnez "Génération procédurale"
Choisissez un type de terrain
Définissez un paramètre de génération (seed)
Ajustez les paramètres d'optimisation
Générez et téléchargez

⚙️ Paramètres Techniques
🔬 Précision

2048×2048 : Standard W&R:SR, génération rapide
4096×4096 : Haute précision, détails fins
8192×8192 : Ultra précision, nécessite plus de RAM
16384×16384 : Extrême, réservé aux PC puissants

🗺️ Niveaux de détail d'élévation

Zoom 10 : ~305m/pixel, vue d'ensemble
Zoom 12 : ~76m/pixel, standard recommandé
Zoom 14 : ~19m/pixel, haute précision
Zoom 16 : ~4.8m/pixel, très haute précision
Zoom 18 : ~1.2m/pixel, précision maximale

🎛️ Paramètres d'optimisation

Niveau marin : Définit l'altitude zéro (mer/lacs)
Coefficient d'élévation : Amplification des hauteurs (10-500%)
Contraste topographique : Accentue les reliefs (0.1-3.0)
Lissage : Réduit le bruit et les artefacts

🎮 Intégration dans W&R:SR
📁 Utilisation des fichiers générés

Les heightmaps sont générées au format PNG noir et blanc
Copiez le fichier dans le dossier des cartes de W&R:SR
Importez via l'éditeur de cartes du jeu
Le terrain est automatiquement sculpté selon la heightmap

🔧 Optimisations automatiques

Bordures noires : Ajoutées automatiquement (requis par W&R:SR)
Format noir et blanc : Optimisé pour l'importation
Analyse terrain : Paramètres configurés selon le type détecté
Compression : Fichiers PNG optimisés

🚨 Résolution des problèmes
❌ Erreurs courantes
"Clé API invalide"

Vérifiez que la clé commence par pk.
Testez la clé avec le bouton de test
Créez une nouvelle clé sur mapbox.com si nécessaire

"Carte ne se charge pas"

Vérifiez votre connexion internet
Testez votre clé API
Essayez le mode génération procédurale

"Génération lente"

Réduisez la résolution (utilisez 2K ou 4K)
Diminuez le niveau de zoom d'élévation
Fermez les autres applications

"Fichier trop volumineux"

Réduisez la résolution
Les fichiers 8K+ peuvent dépasser 50MB

💡 Conseils d'optimisation

Débutants : Utilisez 2048×2048 avec zoom 12
Performances moyennes : 4096×4096 avec zoom 14
PC puissants : 8192×8192+ avec zoom 16+
Test rapide : Mode procédural sans API

📊 Limites et quotas
🆓 Mapbox (gratuit)

50,000 requêtes par mois
Suffisant pour ~100-200 heightmaps selon la précision
Pas de limite sur la génération procédurale

💻 Limites techniques

RAM : Résolutions 8K+ nécessitent 4GB+ de RAM libre
Navigateur : Peut planter sur résolutions extrêmes (16K)
Stockage : Fichiers 16K peuvent atteindre 200MB

🔗 Liens et ressources

🎮 Workers & Resources: Soviet Republic : Steam
🗺️ Mapbox : mapbox.com
📖 Documentation Mapbox API : docs.mapbox.com
💻 Code source : GitHub FXQC98/FXQC

📝 Notes de version
Version 2.0

✅ Suppression de la clé API intégrée
✅ Système de configuration utilisateur
✅ Sauvegarde locale sécurisée
✅ Interface améliorée
✅ Liens GitHub ajoutés

Version 1.0

✅ Génération de heightmaps réelles et procédurales
✅ Interface utilisateur complète
✅ Haute précision jusqu'à 16K
✅ Configuration automatique des paramètres

🛠️ Support
Pour toute question ou problème :

Vérifiez d'abord cette documentation
Testez en mode procédural pour isoler les problèmes d'API
Consultez la console du navigateur (F12) pour les erreurs techniques
Visitez le GitHub du projet pour rapporter des bugs


⭐ Au service de la planification socialiste et de l'édification de votre république industrielle ! ⭐
