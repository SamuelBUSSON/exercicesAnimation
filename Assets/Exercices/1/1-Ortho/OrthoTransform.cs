using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Coordinates/Orthographic Transform", order = 1)]
public class OrthoTransform : CoordinateTransform
{
    public override Vector3 FromCoordinates(Vector3 src)
    {
        return src;
    }

    public override Vector3 ToCoordinates(Vector3 src)
    {
        return src;
    }
}
