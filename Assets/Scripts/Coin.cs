//Author: Rinn Joireman
//This script contains implementation for the coin prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    public float framesPerSecond = 2;
    public Sprite[] frames;
    public GameObject coinExplosion;
    public AudioClip twinkleSound;


    private SpriteRenderer spriteRenderer;
    private float frameTimer;
    private int currentFrameIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        frameTimer = (1f / framesPerSecond);
        currentFrameIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Animation: the animation for the spinning coin is a flipbook that should run endlessly 
        //until the object is removed from the game
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0){
            currentFrameIndex++;
            frameTimer = (1f/framesPerSecond);
            currentFrameIndex = currentFrameIndex%frames.Length;
            spriteRenderer.sprite = frames[currentFrameIndex];
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
//Updated upstream
        //when the player collides with the coin, a sound will be played and the coin explosion prefab will 
        //be instantiated. Then the game object is destroyed and the coin count is incremented.
        
        if(other.CompareTag("Player")){
            AudioSource.PlayClipAtPoint(twinkleSound, transform.position);
            Instantiate(coinExplosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            ScoreTextScript.coinAmount += 1;
        }
        if (!other.CompareTag("Player"))
        {
            return;
        }
        
    }
}
