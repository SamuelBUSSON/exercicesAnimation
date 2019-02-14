using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FOVTextManager : MonoBehaviour
{
    public static float FOV;
    Text text;

    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<Text>();
        FOV = TravellingCameraController.angle;
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "FOV : " + FOV;
    }
}
