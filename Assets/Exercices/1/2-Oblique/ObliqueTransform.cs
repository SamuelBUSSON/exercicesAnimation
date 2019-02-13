using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Coordinates/Oblique Transform", order = 1)]
public class ObliqueTransform : CoordinateTransform
{
    public float yScale = 0.0f;

    public override Vector3 FromCoordinates(Vector3 src)
    {
        return new Vector3(src.x + src.y * yScale, src.y);
    }

    public override Vector3 ToCoordinates(Vector3 src)
    {
        return new Vector3(src.x - src.y * yScale, src.y);
    }
}
