//Author: Rinn Joireman
//This file contains implementation for a platform that moves up and down
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 2;
    public float maxDown = 2; 
    public float maxUp = 2;

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
        //Calculating position: if the platform is at or below the original position MINUS the maxDown variable
        //it changes directions. Similarly, if the platform is at or above the original position PLUS the maxUp
        //it changes directions.
        //the private variable changeSpeed is used instead of the public variable speed because the player should
        //not be able to alter the DIRECTION that the platform is moving inside the game, only the rate of change
        if(ogPos[1] - transform.position[1] >= maxDown)
        {
            changeSpeed = -changeSpeed;
        }
        else if(transform.position[1] -ogPos[1] >= maxUp)
        {
            changeSpeed = -changeSpeed;
        }
        transform.position = transform.position + new Vector3(0, 1, 0) * changeSpeed * Time.deltaTime;

    }
}
