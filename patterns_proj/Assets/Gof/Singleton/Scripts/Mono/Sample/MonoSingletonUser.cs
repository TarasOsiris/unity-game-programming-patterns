using UnityEngine;

public class MonoSingletonUser : MonoBehaviour
{
    void Start()
    {
        MySingletonGameManager.Instance.DoSomeSingletonStuff();
    }
}
