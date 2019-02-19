using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravellingCameraController : MonoBehaviour
{
    public GameObject target;
    public float minDistance, maxDistance;

    private Vector3 targetPos;
    private bool forward;
    private float xpos, ypos, zpos;
    public float horizontalFOVRange;
    public static float distance;
    public static float angle;

    // Start is called before the first frame update
    void Start()
    {
        //Init camera position
        Vector3 targetPos = target.GetComponentInChildren<SkinnedMeshRenderer>().bounds.center;
        xpos = targetPos.x;
        ypos = targetPos.y;
        zpos = targetPos.z - minDistance;

        //Update camera fov and position
        UpdateCamera(new Vector3(xpos, ypos, zpos));
        UpdateUI();

        //Init first direction
        forward = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (forward)
        {
            zpos += 0.1f;
            if (zpos > targetPos.z - minDistance) forward = false;
        }
        else
        {
            zpos -= 0.1f;
            if (zpos < targetPos.z - maxDistance) forward = true;
        }

        UpdateCamera(new Vector3(xpos, ypos, zpos));
        UpdateUI();
    }

    public void UpdateCamera(Vector3 newPosition)
    {
        distance = Vector3.Distance(targetPos, transform.position);
        //Compute FOV angle and convert from radians to degrees
        angle = (180 / Mathf.PI) * Mathf.Atan(horizontalFOVRange / distance);

        transform.position = newPosition;
        Camera.main.fieldOfView = angle * 2;
    }

    public void UpdateUI()
    {
        DistanceTextManager.distance = distance;
        FOVTextManager.FOV = angle * 2;
    }
}
