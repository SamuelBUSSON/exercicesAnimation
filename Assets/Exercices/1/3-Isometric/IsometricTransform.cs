using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Coordinates/Isometric Transform", order = 1)]
public class IsometricTransform : CoordinateTransform
{
    public Vector3 xScale = Vector3.right;
    public Vector3 yScale = Vector3.up;
    public Vector3 zScale = Vector3.forward;

    private Matrix4x4 matrix
    {
        get
        {
            return new Matrix4x4(xScale, yScale, zScale, new Vector4(0, 0, 0, 1)).transpose;
        }
    }

    public override Vector3 FromCoordinates(Vector3 src)
    {
        return matrix.inverse.MultiplyPoint3x4(src);
    }

    public override Vector3 ToCoordinates(Vector3 src)
    {
        return matrix.MultiplyPoint3x4(src);
    }
}
