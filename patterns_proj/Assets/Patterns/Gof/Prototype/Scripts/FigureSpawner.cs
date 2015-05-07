using UnityEngine;
using System.Collections;

public class FigureSpawner : MonoBehaviour
{
    public GameObject blueSpherePrototype;
    public RedCube redCubePrototype;

    public Material greenMaterial;
    private GreenCapsule _greenCapsulePrototype;

    // Initialize Capsule Prototype
    void Start()
    {
        InitCapsulePrototype();
    }

    private void InitCapsulePrototype()
    {
        var capsule = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        
        capsule.AddComponent<Rigidbody>();
        capsule.GetComponent<Renderer>().material = greenMaterial;

        var capsuleBehaviour = capsule.AddComponent<GreenCapsule>();
        capsuleBehaviour.health = 100;
        capsuleBehaviour.mana = 100.0f;

        // Deactivate prototype
        capsuleBehaviour.gameObject.SetActive(false);

        // Finally store counstructed object for cloning
        _greenCapsulePrototype = capsuleBehaviour;
    }

    // From Prefab
    public void SpawnBlueSphere()
    {
        var blueSphere = Object.Instantiate(blueSpherePrototype, Vector3.zero, Quaternion.identity) as GameObject;
        blueSphere.GetComponent<Rigidbody>().velocity = new Vector3(5, 5, 5);
    }

    // Prefab can clone itself
    public void SpawnRedCube()
    {
        var redCube = redCubePrototype.Clone();
        redCube.GetComponent<Rigidbody>().velocity = new Vector3(5, 5, 5);       
    }

    // Construct Object from scratch
    public void SpawnGreenCapsule()
    {
        var capsule = _greenCapsulePrototype.Clone(Vector3.zero, Quaternion.identity);
        capsule.gameObject.SetActive(true);
    }
}
