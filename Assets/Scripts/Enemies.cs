using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    SpriteRenderer sprite;

    public float health = 50f; // can be changed
    public Rigidbody2D rb2d;
    public float speed = 2;
    public GameObject bullet;
    public float rateofFire;
    private float lastShot= 0;
    private float defaultSpeed = 0;
    private Boolean correctCollider;


    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }



    public Boolean playerTracker()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left,10f,8);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right,10f,8);


        

        if (left.collider)
        {
            if (left.collider.CompareTag("Player"))
            {
                if ((lastShot + 1 / rateofFire) < Time.time)
                {
                    lastShot = Time.time;
                    Instantiate(bullet, transform.position, Quaternion.identity);

                }
                return true;
            }

        }



        if (right.collider)
        {
            if (right.collider.CompareTag("Player"))
            {
                if ((lastShot + 1 / rateofFire) < Time.time)
                {
                    lastShot = Time.time;
                    Instantiate(bullet, transform.position, Quaternion.identity);


                }
                return true;
            }
        }

        return false;
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            correctCollider=false;
        }
        correctCollider= true;
    }


    public Boolean canMoveForward()
    {
        //Have to play around with this implenmentation in order to get the correct angle.
        //Found that while it will stop, it will not flip and go into the other direction. I might need to implement that within this
        //function instead of the update function
        //tried it several ways, ititally using cos and sin as i had seen online. after lots of failure, I changed to Vector2 instead, and
        //use -1,-1 to get the vecotr going at the angle that I wanted. It worked. Now i had to edit my function to get the enemey to flip directions

        Vector2 currentDirection;
        if (sprite.flipX == false)
        {
            currentDirection = new Vector2(1, -1);
        }
        else
        {
            currentDirection = new Vector2(-1, -1);
        }


        RaycastHit2D forward = Physics2D.Raycast(transform.position, currentDirection);
        if (forward.collider == null)
        {
            return false;

        }


        return true;
    }

    //Shoot raycast at 45 degree angle to check if enemy can still move forward without falling off of platform

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
        
}



    void Update()

    {
        if (playerTracker())
        {
            speed =0;
        }
        else
        {
            speed = defaultSpeed;
        }


        if (canMoveForward() == true)
        {
            switch (sprite.flipX)
            {
                case false:
                    transform.position += Vector3.right * speed * Time.deltaTime;
                    break;

                case true:
                    transform.position += Vector3.left * speed * Time.deltaTime;
                    break;


            }




        }
        else if (sprite.flipX == false)
        {
            sprite.flipX = true;
        }
        else if (sprite.flipX == true)
        {
            sprite.flipX = false;
        }
    }
}



