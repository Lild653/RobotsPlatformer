//Author: Rinn Joireman
//This file contains implementation for a platform that moves horizontally.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlatform : MonoBehaviour
{
     // Start is called before the first frame update
    public float speed = 2;
    public float maxLeft = 0; 
    public float maxRight = 2;

    private float changeSpeed;
    private Vector3 ogPos;

    void Start()
    {
        changeSpeed = speed;
        ogPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Calculating position: if the platform is at or below the original position MINUS the maxLeft variable
        //it changes directions. Similarly, if the platform is at or above the original position PLUS the maxRight
        //it changes directions.
        //the private variable changeSpeed is used instead of the public variable speed because the player should
        //not be able to alter the DIRECTION that the platform is moving inside the game, only the rate of change
        if(ogPos[0] - transform.position[0] >= maxLeft)
        {
            changeSpeed = -changeSpeed;
        }
        else if(transform.position[0] -ogPos[0] >= maxRight)
        {
            changeSpeed = -changeSpeed;
        }
        transform.position = transform.position + new Vector3(1, 0, 0) * changeSpeed * Time.deltaTime;

    }
}
