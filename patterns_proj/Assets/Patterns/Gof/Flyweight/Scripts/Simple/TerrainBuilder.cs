using UnityEngine;
using System.Collections;

public class TerrainBuilder : MonoBehaviour
{
    public GameObject grassTerrainPrefab;
    public GameObject waterTerrainPrefab;

    void Start()
    {
        ConstructTerrain();  
    }

    private void ConstructTerrain()
    {
        for (int i = 0; i < 100; i++)
        {
            for (int j = 0; j < 100; j++) 
            {
                var curPrefab = i % 3 == 0 || j % 5 == 0? grassTerrainPrefab : waterTerrainPrefab;
                var terrainVoxel = Object.Instantiate(curPrefab, new Vector3(i, j), Quaternion.identity) as GameObject;
                terrainVoxel.transform.SetParent(transform);
            }
        }
    }
}
