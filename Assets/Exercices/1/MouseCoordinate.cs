using UnityEngine;

public class MouseCoordinate : MonoBehaviour
{
    public CoordinateTransform coordinateTransform;

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 transformed = coordinateTransform.ToCoordinates(worldPosition);
            Vector3 verification = coordinateTransform.FromCoordinates(transformed);

            Debug.Log(string.Format("World: {0} --> Transform: {1} --> Check: {2}", worldPosition, transformed, verification));
        }
    }
}
