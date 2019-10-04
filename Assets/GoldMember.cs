using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldMember : MonoBehaviour
{
    private SpriteRenderer goldilocks;
    // Start is called before the first frame update
    void Start()
    {
        goldilocks = GetComponent<SpriteRenderer>();
        goldilocks.color = Color.yellow;
    }

    

    // Update is called once per frame
    void Update()
    {
       
    }
}
