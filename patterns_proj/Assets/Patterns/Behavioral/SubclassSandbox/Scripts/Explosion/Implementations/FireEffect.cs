using UnityEngine;

public class FireEffect : VisualEffect
{
    protected override void Start()
    {
        Debug.Log("BombExplosion Start()");
        SpawnParticles();
        DoBombSpecificStuff();
    }

    private void DoBombSpecificStuff()
    {
        Debug.Log("DoBombSpecificStuff");       
    }
}
