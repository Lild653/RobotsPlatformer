using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public float offsetX;
    public float offsetY;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
        if(player.position.y < (pos.y - offsetY))
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
