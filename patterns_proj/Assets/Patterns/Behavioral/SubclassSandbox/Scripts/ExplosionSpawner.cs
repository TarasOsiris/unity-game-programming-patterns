using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public GameObject dynamite;
    public GameObject bomb;

    public void SpawnDynamiteExplosion()
    {
        var obj = Object.Instantiate(dynamite, Vector3.zero, Quaternion.identity);
        Object.Destroy(obj, 2.0f);
    }

    public void SpawnBombExplosion()
    {
        var obj = Object.Instantiate(bomb, Vector3.zero, Quaternion.identity);     
        Object.Destroy(obj, 2.0f);        
    }
}
