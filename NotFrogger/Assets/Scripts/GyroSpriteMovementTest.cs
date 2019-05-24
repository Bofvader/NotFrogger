﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GyroSpriteMovementTest : MonoBehaviour
{
    public Vector3 deviceAcceleration;
    // Start is called before the first frame update
    void Start()
    {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        GetComponent<Camera>().transform.position = new Vector3(0, 0, 0);
        
    }

    // Update is called once per frame
    void Update()
    {
        deviceAcceleration = Input.acceleration;
        transform.position = deviceAcceleration;
    }
}
