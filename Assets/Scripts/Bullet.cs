using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Author: Danny
public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private float range = 6f;
    public float speed;
    private Vector2 bulletTravel;
    SpriteRenderer bulletSprite;
    public string bulletDirection;
  
    


    private void Start()
    {
        bulletSprite = GetComponent<SpriteRenderer>();
        bulletTravel = transform.position;

    }

    //determines orientation of bullet and passes a string into bulletDirection
    void bulletPath()
    {
        if (bulletSprite.flipX)
        {
            bulletDirection = "left";
        }
        else
        {
            bulletDirection = "right";
        }
    }

    private void Update()
    {


        bulletPath();
        //moves bullet depending on which direction it needs to go in
        switch (bulletDirection)
        {
            case "left":
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (Mathf.Abs(transform.position.x - bulletTravel.x) >= range)
                {
                    Destroy(gameObject);
                }
                break;
            case "right":
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (Mathf.Abs(bulletTravel.x - transform.position.x) >= range)
                {
                    Destroy(gameObject);
                }
                break;

        }
        
        
    }

}

