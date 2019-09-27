using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    SpriteRenderer sprite;

    public float health = 50f; // can be changed
    public Rigidbody2D rb2d;

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



    void playerTracker()
    {
        RaycastHit2D left = Physics2D.Raycast(transform.position, Vector2.left, 5f);
        RaycastHit2D right = Physics2D.Raycast(transform.position, Vector2.right, 5f);


        if (left.collider.CompareTag("Player"))
        {
            GetComponent<Bullet>();
        }
        if (right.collider.CompareTag("Player"))
        {
            sprite.flipY = true;
            GetComponent<Bullet>();
        }
    }


    public Boolean canMoveForward()
    {
        var direction = new Vector3(Mathf.Cos(45), Mathf.Sin(45), 0f);
        RaycastHit2D forward = Physics2D.Raycast(transform.position, direction);
        if(forward.collider==null)
        {
            return false;
        }


        return true;
    }

    //Shoot raycast at 45 degree angle to check if enemy can still move forward without falling off of platform

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }



    private void Update()
    {
        if (canMoveForward() == true)
        {
            rb2d.velocity
        }
    }
}



