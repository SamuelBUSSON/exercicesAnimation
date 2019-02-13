using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Coordinates/Polar Transform", order = 1)]
public class PolarTransform : CoordinateTransform
{
    public override Vector3 FromCoordinates(Vector3 src)
    {
        float rad = Mathf.Deg2Rad * src.x;
        return new Vector3(src.y * Mathf.Cos(rad), src.y * Mathf.Sin(rad), src.z);
    }

    public override Vector3 ToCoordinates(Vector3 src)
    {
        return new Vector3(Mathf.Rad2Deg * Mathf.Atan2(src.y, src.x), ((Vector2)src).magnitude, src.z);
    }
}
