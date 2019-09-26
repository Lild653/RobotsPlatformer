
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
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
}

