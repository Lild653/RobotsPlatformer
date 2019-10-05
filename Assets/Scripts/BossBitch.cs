using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBitch : MonoBehaviour
{

    SpriteRenderer sprite;
    public float health = 60f; // can be changed
    public Rigidbody2D rb2d;
    public float speed = 2;
    public GameObject bullet;
    public float rateofFire;
    private float lastShot = 0;
    private float defaultSpeed = 2;
    private Boolean correctCollider;
    public float animationTimer = 0;
    private int currentFrame = 0;
    public float animationFPS = 5;
    public Sprite[] movement;
    public Sprite shootStance;
    public Sprite[] deadBitch;
    public Sprite[] hurtBitch;
    private SpriteRenderer bulletSprite;
    public GameObject portal;


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
        Instantiate(portal, transform.position, Quaternion.identity);
        Destroy(gameObject);
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            TakeDamage(20);
            Destroy(collision.gameObject);
        }
        else
        {
            return;
        }
    }





    public Boolean playerTracker()
    {
        Vector2 leftHit = new Vector2(-1, -1);
        Vector2 rightHit = new Vector2(1, -1);
        RaycastHit2D left = Physics2D.Raycast(transform.position, leftHit);
        RaycastHit2D right = Physics2D.Raycast(transform.position, rightHit);




        if (left.collider)
        {
            if (left.collider.CompareTag("Player"))
            {
                sprite.flipX = true;
                if ((lastShot + 1 / rateofFire) < Time.time)
                {
                    lastShot = Time.time;
                    bulletSprite.flipX = true;
                    Instantiate(bullet, transform.position, Quaternion.identity);

                }

                return true;
            }

        }



        if (right.collider)
        {
            if (right.collider.CompareTag("Player"))
            {
                sprite.flipX = false;
                if ((lastShot + 1 / rateofFire) < Time.time)
                {
                    lastShot = Time.time;
                    bulletSprite.flipX = false;
                    Instantiate(bullet, transform.position, Quaternion.identity);


                }

                return true;
            }
        }

        return false;


    }





    public void PlayBackAnimation(Sprite[] anim)
    {
        animationTimer -= Time.deltaTime;
        if (animationTimer <= 0 && anim.Length > 0)
        {
            animationTimer = 1f / animationFPS;
            currentFrame++;
            if (currentFrame >= anim.Length)
            {
                currentFrame = 0;
            }
            sprite.sprite = anim[currentFrame];
        }
    }
    public Boolean canMoveForward()
    {
        //Have to play around with this implenmentation in order to get the correct angle.
        //Found that while it will stop, it will not flip and go into the other direction. I might need to implement that within this
        //function instead of the update function
        //tried it several ways, ititally using cos and sin as i had seen online. after lots of failure, I changed to Vector2 instead, and
        //use -1,-1 to get the vecotr going at the angle that I wanted. It worked. Now i had to edit my function to get the enemey to flip directions

        Vector2 currentDirection;
        RaycastHit2D frontDirection;
        Vector2 right = new Vector2(1, 0);
        Vector2 left = new Vector2(-1, 0);
        if (sprite.flipX == false)
        {
            currentDirection = new Vector2(1, -1);
            frontDirection = Physics2D.Raycast(transform.position, right, 5f);
        }
        else
        {
            currentDirection = new Vector2(-1, -1);
            frontDirection = Physics2D.Raycast(transform.position, left, 5f);
        }

        RaycastHit2D forward = Physics2D.Raycast(transform.position, currentDirection, 10f);

        if (forward.collider == null || forward.collider.CompareTag("Spike"))
        {

            return false;
        }

        else if (frontDirection.collider == null)
        {

            return true;
        }
        else if (frontDirection.collider.CompareTag("Player"))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    //Shoot raycast at 45 degree angle to check if enemy can still move forward without falling off of platform

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        bulletSprite = bullet.GetComponent<SpriteRenderer>();


    }

    IEnumerator waiting()
    {
        sprite.sprite = shootStance;
        yield return new WaitForSeconds(1);
    }



    void Update()

    {
        if (playerTracker())
        {
            speed = 0;

            StartCoroutine(waiting());
        }
        else if ((canMoveForward() == true))
        {
            speed = defaultSpeed;
            PlayBackAnimation(movement);
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






