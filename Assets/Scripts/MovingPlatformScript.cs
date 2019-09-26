//Author: Rinn
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
    private Vector3 upPos;
    private Vector3 downPos;
    void Start()
    {
        changeSpeed = speed;
        ogPos = transform.position;
        upPos = ogPos + new Vector3(0,2,0);
        downPos = ogPos + new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
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
