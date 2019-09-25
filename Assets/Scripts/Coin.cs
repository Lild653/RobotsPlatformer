//Author: Rinn Joireman

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
        // currentFrameIndex++;
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0){
            currentFrameIndex++;
            frameTimer = (1f/framesPerSecond);
            currentFrameIndex = currentFrameIndex%frames.Length;
            spriteRenderer.sprite = frames[currentFrameIndex];
        }
    }

    void OnCollisionEnter2D()
    {

        Debug.Log("bitchasssss");
        AudioSource.PlayClipAtPoint(twinkleSound, transform.position);
        Instantiate(coinExplosion, transform.position, Quaternion.identity);
        ScoreTextScript.coinAmount += 1;
        Destroy(gameObject);
    }
}
