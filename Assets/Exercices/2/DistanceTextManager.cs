using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceTextManager : MonoBehaviour
{
    public static float distance;
    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        distance = TravellingCameraController.distance;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Distance : " + distance;
    }
}
