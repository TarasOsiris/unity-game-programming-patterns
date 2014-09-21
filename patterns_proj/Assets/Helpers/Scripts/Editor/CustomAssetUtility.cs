using UnityEngine;
using UnityEditor;
using System.IO;

/// <summary>
/// Taken from here : http://www.jacobpennock.com/Blog/?page_id=715 and modified
/// </summary>
public static class CustomAssetUtility
{
    [MenuItem("Assets/Create/Airplane Config File")]
    public static void CreateAirplaneConfig()
    {
        CreateAsset<PlaneTechSpecs>();
    }

    public static void CreateAsset<T>() where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T>();
        
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);
        if (path == string.Empty)
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != string.Empty)
        {
            path = path.Replace(Path.GetFileName(AssetDatabase.GetAssetPath(Selection.activeObject)), string.Empty);
        }
        
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath(path + "/New " + typeof(T).ToString() + ".asset");
        
        AssetDatabase.CreateAsset(asset, assetPathAndName);
        AssetDatabase.SaveAssets();
        EditorUtility.FocusProjectWindow();
        Selection.activeObject = asset;
    }
}