using UnityEngine;
using UnityEditor;

public class DataAsset
{
    [MenuItem("Assets/Create/DataAsset")]
    public static void CreateAsset()
    {
        ScriptableObjectUtility.CreateAsset<UserDataSave>();
    }
}