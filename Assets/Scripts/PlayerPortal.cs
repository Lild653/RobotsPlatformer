using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPortal : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rb2d;

    private float spinTimer = 3;
    private float rotationSpeed = 200;
    public SpriteRenderer sr;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(spinTimer > 0)
        {
            //sr.size -= new Vector2(0.01f, 0.01f);
            spinTimer -= Time.deltaTime;
            rotationSpeed += 10;
            Quaternion quat = Quaternion.AngleAxis(rotationSpeed*Time.deltaTime, Vector3.forward);
            transform.rotation *= quat;
        }
    else
        {
            Destroy(gameObject);
        }
    }
}
