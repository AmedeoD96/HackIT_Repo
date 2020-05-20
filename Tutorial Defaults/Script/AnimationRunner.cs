using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]

public class AnimationRunner : MonoBehaviour
{
    SpriteRenderer spritesRenderer = default;
    [SerializeField] List<Sprite> sprites = default;
    [SerializeField] bool isActive;
    int indexAnimation = 0;
    float timer;
    [SerializeField] int spritesPerSecond = 10;

    public void setActive(bool isActive)
    {
        this.isActive = isActive;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            if(timer <= 0f)
            {
                NextSprite();
                ResetTimer();
            }
            else
            {
                timer -= Time.deltaTime;
            }
        }
    }

    private void Awake()
    {
        spritesRenderer = GetComponent<SpriteRenderer>();
    }

    private void NextSprite()
    {
        spritesRenderer.sprite = sprites[indexAnimation];
        indexAnimation++;
        if (indexAnimation >= sprites.Count)
        {
            indexAnimation = 0;
        }
    }

    private void ResetTimer()
    {
        timer = 1f / spritesPerSecond;
    }
}
