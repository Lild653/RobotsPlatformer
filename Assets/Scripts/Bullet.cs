using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    private float range = 3f;
    public float speed;
    private Vector2 bulletTravel;
    SpriteRenderer bulletSprite;


    private void Start()
    {
        bulletSprite = GetComponent<SpriteRenderer>();
        bulletTravel = transform.position;

    }



    void bulletDeath()
    {

        StartCoroutine(smokingGun());
    }


    IEnumerator smokingGun()
    {

        yield return new WaitForSeconds(1/5);
        Destroy(gameObject);
    }


    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
        if(Mathf.Abs(transform.position.x+bulletTravel.x) >= range)
        {
            bulletDeath();
        }
    }












    /*
    
    public GameObject player;
    SpriteRenderer sr;
    SpriteRenderer enemy;
    public GameObject bullet;
    
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        enemy = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit2D shot = Physics2D.Raycast(sr.transform.position, sr.transform.forward, range);
        if (shot.collider!= null)
        {
            print("collider");
            GameObject copybullet = Instantiate(bullet, transform.position, Quaternion.identity);
            Rigidbody2D rb2d = copybullet.GetComponent<Rigidbody2D>();
            rb2d.velocity = new Vector2(1, 0) * 10;
            
            //Destroy(shot.collider.enemy);
        }


            //Debug.Log(hit.transform.name);
            //SpriteRenderer target = hit.transform.enemy;
            //if (target != null)
            //{
            //    target.TakeDamage(damage);
            //}
    }
    */
}

