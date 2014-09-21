using UnityEngine;

public class FireEffect : VisualEffect
{
    protected override void Start()
    {
        base.Start();
        Debug.Log("BombExplosion Start()");
        DoFireSpecificStuff();
    }

    private void DoFireSpecificStuff()
    {
        Debug.Log("DoBombSpecificStuff");       
    }
}
