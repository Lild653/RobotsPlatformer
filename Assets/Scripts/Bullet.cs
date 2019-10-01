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
    public string bulletDirection;
    public string bulletType;
    public Sprite[] bulletAnim;
    


    private void Start()
    {
        bulletSprite = GetComponent<SpriteRenderer>();
        bulletTravel = transform.position;

    }



    


    IEnumerator smokingGun()
    {
        for(int i = 0; i < bulletAnim.Length; i++)
            {
                bulletSprite.sprite = bulletAnim[i];
                yield return new WaitForSeconds(1/20f);
            }
        
        Destroy(gameObject);
    }

    

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
        switch (bulletDirection)
        {
            case "left":
                transform.position += Vector3.left * speed * Time.deltaTime;
                if (Mathf.Abs(transform.position.x - bulletTravel.x) >= range)
                {
                    StartCoroutine(smokingGun());
                }
                break;
            case "right":
                transform.position += Vector3.right * speed * Time.deltaTime;
                if (Mathf.Abs(bulletTravel.x - transform.position.x) >= range)
                {
                    StartCoroutine(smokingGun());
                }
                break;

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

