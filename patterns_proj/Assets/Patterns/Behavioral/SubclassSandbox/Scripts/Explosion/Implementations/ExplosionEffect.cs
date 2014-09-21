using UnityEngine;

public class ExplosionEffect : VisualEffect
{
    public GameObject additionalDynamiteEffect;

    protected override void Start()
    {
        base.Start();

        Debug.Log("DynamiteExplosion Start()");
        DoExplosionSpecificStuff();
    }

    private void DoExplosionSpecificStuff()
    {
        NGUITools.AddChild(gameObject, additionalDynamiteEffect); 
    }
}
