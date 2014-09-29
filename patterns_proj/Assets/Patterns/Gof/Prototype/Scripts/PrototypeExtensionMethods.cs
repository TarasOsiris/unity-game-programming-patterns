using UnityEngine;

public static class PrototypeExtensionMethods
{
    #region cloning
    public static T Clone<T>(this T unityObj) where T : Object
    {
        return Object.Instantiate(unityObj) as T;
    }

    public static T Clone<T>(this T unityObj, Vector3 position, Quaternion rotation) where T : Object
    {
        return Object.Instantiate(unityObj, position, rotation) as T;
    }
    #endregion
}
