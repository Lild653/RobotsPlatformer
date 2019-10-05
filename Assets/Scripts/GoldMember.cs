using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Author: Danny
public class GoldMember : MonoBehaviour
{
    private SpriteRenderer goldilocks;

    //Just changes the color to yellow
    void Start()
    {
        goldilocks = GetComponent<SpriteRenderer>();
        goldilocks.color = Color.yellow;
    }

    

    
}
