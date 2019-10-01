//Authors: Rinn and Liya
//This script contains implementation for the movement of the camera during game play
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetX;
    public float offsetY;
    public bool moveY;
    // Start is called before the first frame update
    void Start()
    {

    }

    //Update is called once per frame
    void Update()
    {
        //The camera should always follow the player in the x direction
        Vector3 pos = transform.position;
        if (player.position.x > (pos.x - offsetX))
        {
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
        else if (player.position.x < (pos.x - offsetX))
        {
            pos.x = player.position.x + offsetX;
            transform.position = pos;
        }
        //If a scene needs the camera to move in the Y direction, we can check moveY as true and the
        //camera will also change based on the players Y direction
        if (moveY == true)
        {
            if (player.position.y < (pos.y - offsetY))
            {
                pos.y = player.position.y - offsetY;
                transform.position = pos;
            }
            else if (player.position.y > (pos.y - offsetY))
            {
                pos.y = player.position.y + offsetY;
                transform.position = pos;
            }
        }
    }

}
