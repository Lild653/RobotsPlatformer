﻿//Author: Rinn Joireman
//File that contains the implementation for the invisible platform.
//This platform is essentially just a looped sprite flipbook with a square collider attached to it

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatformScript : MonoBehaviour
{
    public float framesPerSecond = 2;
    public Sprite[] frames;

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
        //Animation: twinkling star animations are looped indefinitely 
        frameTimer -= Time.deltaTime;
        if(frameTimer <= 0){
            currentFrameIndex++;
            frameTimer = (1f/framesPerSecond);
            currentFrameIndex = currentFrameIndex%frames.Length;
            spriteRenderer.sprite = frames[currentFrameIndex];
        }
    }
}
