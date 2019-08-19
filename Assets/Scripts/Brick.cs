﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

[RequireComponent(typeof(SpriteRenderer))]
public class Brick : MonoBehaviour
{
    [Tooltip("Should we cause the camera to shake if the ball this thie brick.")]
    public bool causeCameraShake = false;
    public bool isBreakable = true;

    [Tooltip("Number of srites = number of hits the brick can take")]
    public List<Sprite> sprites = new List<Sprite>();

    private SpriteRenderer spriteRender;



    private void Awake()
    {
        spriteRender = GetComponent<SpriteRenderer>();
        Assert.IsNotNull(spriteRender, "Failed to find Sprite Renderer component.");

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (causeCameraShake)
        {
            // Todo: Create camera shake
            GameCamera.instance.cameraShake.Shake();
        }
        if (!isBreakable)
            return;

        if (sprites.Count > 0)
        {
            sprites.RemoveAt(0);
            if (sprites.Count > 0)
            {
                spriteRender.sprite = sprites[0];
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
