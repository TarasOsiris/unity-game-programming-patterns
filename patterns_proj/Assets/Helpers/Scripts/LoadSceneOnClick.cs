using UnityEngine;

public class LoadSceneOnClick : MonoBehaviour
{
    public string sceneName;

    void OnClick()
    {
        Application.LoadLevel(sceneName);
    }
}
