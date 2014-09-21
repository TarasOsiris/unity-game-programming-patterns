using UnityEngine;

public class PlaneTechSpecs : ScriptableObject
{
    public enum AirPlaneType
    {
        JetPlane,
        AirPlane
    }

    public AirPlaneType airPlaneType;
    public string serialNumber;
    public int maxSpeed;
}
