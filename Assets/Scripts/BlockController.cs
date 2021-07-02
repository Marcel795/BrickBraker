using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockController : MonoBehaviour
{
    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockDestroyEffect;
    [SerializeField] int maxHits = 0;
    [SerializeField] Sprite[] sprite;
    [SerializeField] int hits = 0;
    [SerializeField] Sprite[] hitSprites;
    LevelController level;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ShowEffect();
        if (tag == "Breakable")
        {
            //wenn hits >= maxhits => zerstöre denn Block
            DestroyBlock();
        }

    }

    private void ShowEffect()
    {
        Instantiate(blockDestroyEffect, transform.position, transform.rotation);
    }

    void Start()
    {
        level.CountBreakableBlocks();
        level = FindObjectOfType<LevelController>();
    }

    private void DestroyBlock()
    {
        Destroy(gameObject);
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        level.DestroyBlock();
        var gameStatus = FindObjectOfType<GameStatusController>();
        gameStatus.ScoreCalculator();
        if (hits >= maxHits)
        {
            DestroyBlock();
        }
        else
        {
            ShowNextHitSprite();
        }

    }

    private void ShowNextHitSprite()
    {
        GetComponent<SpriteRenderer>().sprite = hitSprites[hits - 1];
    }
    
   

}
