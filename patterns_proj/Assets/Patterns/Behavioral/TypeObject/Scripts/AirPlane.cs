using UnityEngine;

public class AirPlane : MonoBehaviour
{
    public PlaneTechSpecs techSpecs;

    private string _serialNumber;
    private int _maxSpeed;

    void Awake()
    {
        NGUITools.AddChild(gameObject, techSpecs.wingsPrefab);
        _serialNumber = techSpecs.serialNumber;
        _maxSpeed = techSpecs.maxSpeed;
    }
}
