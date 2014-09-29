using UnityEngine;

public class RedCube : MonoBehaviour
{
    public RedCube Clone()
    {
        return Instantiate(this) as RedCube;
    }
}
