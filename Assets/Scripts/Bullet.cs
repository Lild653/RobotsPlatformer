
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public LineRenderer laserLineRenderer;
    public GameObject bul;
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCam; // this is going to be the player
    // Start is called before the first frame update
    void Start()
    {
        bul = GetComponent<GameObject>();

    }
    //IEnumerator shoot()
    //{
    //    yield return new WaitForSeconds(.1f);
    //    Rigidbody proj = Instantiate(bul, transform.position, transform.rotation)as Rigidbody;
    //    proj.velocity = transform.TransformDirection(new Vector3(0, 0, 20));
    //}
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

        }
       
    }
   
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
}
