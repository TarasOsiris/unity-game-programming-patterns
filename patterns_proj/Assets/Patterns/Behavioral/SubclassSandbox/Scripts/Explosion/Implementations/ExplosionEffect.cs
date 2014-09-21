using UnityEngine;

public class ExplosionEffect : VisualEffect
{
    public GameObject additionalDynamiteEffect;

    protected override void Start()
    {
        Debug.Log("DynamiteExplosion Start()");
        SpawnParticles();
        DoDynamiteSpecificStuff();
    }

    private void DoDynamiteSpecificStuff()
    {
        NGUITools.AddChild(gameObject, additionalDynamiteEffect); 
    }
}
