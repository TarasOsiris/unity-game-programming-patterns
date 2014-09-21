using UnityEngine;

public abstract class VisualEffect : MonoBehaviour
{
    public GameObject explosionPrefab;

    protected virtual void Start()
    {
        SpawnParticles();
        Debug.Log("BaseExplosion Start()");
    }
    
    protected void SpawnParticles()
    {
        NGUITools.AddChild(gameObject, explosionPrefab);
    }
}
