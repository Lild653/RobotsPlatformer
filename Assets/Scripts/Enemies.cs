using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }



    void playerTracker()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, 5f);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, 5f);

        if (left.collider.CompareTag("Player"))
        {

        }
        if (right.collider.CompareTag("Player"))
        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
