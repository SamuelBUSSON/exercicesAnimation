using UnityEngine;

public abstract class CoordinateTransform : ScriptableObject
{
    public abstract Vector3 ToCoordinates(Vector3 src);
    public abstract Vector3 FromCoordinates(Vector3 src);
}
