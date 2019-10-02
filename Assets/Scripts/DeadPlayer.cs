﻿//this code was added to be attached to the dead player prefab
//it is instantiated when the player collides with the spikes and causes the sprite to bounce up
//then fall off the screen.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class DeadPlayer : MonoBehaviour {

	public float destroyTimer = 3;
	public float upBounceForce = 5;
	public float gravity = 40;

	Rigidbody2D rb2d;

	void Start () {
        ScoreTextScript.coinAmount = 0;
        rb2d = GetComponent<Rigidbody2D> ();
		StartCoroutine (DestroyRoutine ());
		rb2d.velocity = new Vector2 (0, upBounceForce);
	}

	void Update(){
		Vector2 vel = rb2d.velocity;
		vel.y -= gravity * Time.deltaTime;
		rb2d.velocity = vel;
	}

	IEnumerator DestroyRoutine(){
		yield return new WaitForSeconds (destroyTimer);
		Destroy (gameObject);
        

    }

}
