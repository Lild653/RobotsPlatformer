using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    SpriteRenderer sprite;

    public float health = 60f; // can be changed
    public Rigidbody2D rb2d;
    public float speed = 2;
    public GameObject bullet;
    public float rateofFire;
    private float lastShot = 0;
    private float defaultSpeed = 2;
    public float animationTimer = 0;
    private int currentFrame = 0;
    public float animationFPS = 5;
    public Sprite[] movement;
    public Sprite shootStance;
    private SpriteRenderer bulletSprite;


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


    //Detects damage
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




    //Shoots raycast in in both left and right direction of the player and then
    //checks the colliders to see if the player object gets hit. If so, the sprite
    //changes direction toward player and intstantiates a bullet. It then returns
    //a boolean depending on whether or not the player was found by raycast
    public Boolean playerTracker()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, 3f);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, 3f);
        



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




    //Taken from Benno code
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
            frontDirection = Physics2D.Raycast(transform.position, right, 1f);
        }
        else
        {
            currentDirection = new Vector2(-1, -1);
            frontDirection = Physics2D.Raycast(transform.position, left, 1f);
        }

        RaycastHit2D forward = Physics2D.Raycast(transform.position, currentDirection, 2f);

        //if there is no more ground, or there is a spike
        if (forward.collider == null || forward.collider.CompareTag("Spike"))
        {

            return false;
        }
        //if there is no wall/obstacle
        else if (frontDirection.collider == null)
        {

            return true;
        }
        //if the player is in front
        else if (frontDirection.collider.CompareTag("Player"))
        {
            return true;
        }
        //if there is an obstacle
        else
        {
            return false;
        }
    }


    
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        bulletSprite = bullet.GetComponent<SpriteRenderer>();
        
        
}
    //Shooting stance animation
    IEnumerator waiting()
    {
        sprite.sprite = shootStance;
        yield return new WaitForSeconds(1);
    }



    void Update()

    {
        //stops enemy if it's shooting
        if (playerTracker())
        {
            speed = 0;

            StartCoroutine(waiting());
        }
        //if it can move, the enemy continues in the directio
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
        //otherwise it flips whatever direction it is in
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




