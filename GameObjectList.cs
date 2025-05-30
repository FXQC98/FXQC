using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "GameObjectList", menuName = "Custom/GameObject List")]
public class GameObjectList : ScriptableObject
{
    public List<GameObject> objects = new List<GameObject>();
}