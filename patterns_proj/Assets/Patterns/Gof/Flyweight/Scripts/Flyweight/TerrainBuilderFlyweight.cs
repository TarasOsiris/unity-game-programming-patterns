using UnityEngine;
using System.Collections;

public class TerrainBuilderFlyweight : MonoBehaviour
{
    public GameObject grassTerrainPrefab;
    public GameObject waterTerrainPrefab;

    public TerrainProperties _grassProperties;
    public TerrainProperties _waterProperties;

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
                bool isGrass = IsGrass(i, j);
                var curPrefab = IsGrass(i, j) ? grassTerrainPrefab : waterTerrainPrefab;
                var terrainVoxel = Object.Instantiate(curPrefab, new Vector3(i, j), Quaternion.identity) as GameObject;

                if (isGrass)
                {
                    terrainVoxel.GetComponent<FlyweightTerrainVoxel>().terrainProperties = _grassProperties;
                }
                else
                {
                    terrainVoxel.GetComponent<FlyweightTerrainVoxel>().terrainProperties = _waterProperties;                  
                }
            }
        }
    }

    private bool IsGrass(int i, int j)
    {
        return i % 3 == 0 || j % 5 == 0;
    }
}
