// <copyright file="PlayerInputModule2D.cs" company="DIS Copenhagen">
// Copyright (c) 2017 All Rights Reserved
// </copyright>
// <author>Benno Lueders</author>
// <date>07/14/2017</date>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Module for player controller input when using a PlatformController2D. Uses standart Horizontal and Vertical input axis as well as Jump button.
/// </summary>
[RequireComponent (typeof(PlatformerController2D))]
public class PlayerInputModule2D : MonoBehaviour
{
	PlatformerController2D controller;
    private float lastShot;
    private float rateOfFire = 1;
    public GameObject bullet;
    public Sprite[] shooting;

	void Start ()
	{
		controller = GetComponent<PlatformerController2D> ();
        
	}


    void shootingMechanic()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<PlatformerController2D>().PlayBackAnimation(shooting);
            if((lastShot + 1 / rateOfFire) < Time.time){
                // StartCoroutine(shootingAnimation());
                //lastShot = Time.time;
                Instantiate(bullet, transform.position, Quaternion.identity);
            }
        }

    }

    

    IEnumerator shootingAnimation()
    {

        yield return new WaitForSeconds(10);
    }

	void Update ()
	{
        shootingMechanic();
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		if (input.magnitude > 1) {
			input.Normalize ();
		}
		controller.input = input;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            controller.inputJump = true;
        }
	}
}
