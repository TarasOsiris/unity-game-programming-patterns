using UnityEngine;

public class MySingletonGameManager : MonoSingleton<MySingletonGameManager>
{
    public int SomeValue {
        get {
            return _someValue;
        }
    }

    private int _someValue;

    public override void Init()
    {
        Debug.Log("MySingletonGameManager initialized");
        base.Init();
    }

    public void DoSomeSingletonStuff()
    {
        _someValue++;
        Debug.Log("Doing some serious singleton stuff");
    }
}
