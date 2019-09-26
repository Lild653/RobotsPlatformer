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

    private Vector3 upPos;
    private Vector3 downPos;
    void Start()
    {
        Vector3 ogPos = transform.position;
        upPos = ogPos + new Vector3(0,2,0);
        downPos = ogPos + new Vector3(0,2,0);
    }

    // Update is called once per frame
    void Update()
    {
        if(upPos[1] - transform.position[1] >= maxUp)
        {
            speed = -speed;
        }
        else if(transform.position[1] - downPos[1] >= maxDown)
        {
            speed = -speed;
        }
        transform.position = transform.position + new Vector3(0, 1, 0) * speed * Time.deltaTime;

    }
}
