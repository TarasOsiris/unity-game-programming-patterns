using UnityEngine;

public class MySingletonGameManager : MonoSingleton<MySingletonGameManager>
{
    public override void Init()
    {
        Debug.Log("MySingletonGameManager initialized");
        base.Init();
    }

    public void DoSomeSingletonStuff()
    {
        Debug.Log("Doing some serious singleton stuff");
    }
}
