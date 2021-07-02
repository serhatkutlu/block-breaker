using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class block : MonoBehaviour
{
    GameManager gm;
    int block_level;
    void Start()
    {
        gm = GameObject.FindObjectOfType<GameManager>();
        
        gm.block_count++;
        block_level = gm.block_level;
         
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("ball"))
        {
            if (block_level>-1)
            {
                Break(block_level);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }

    private void Break(int sprite_count)
    {
        GetComponent<SpriteRenderer>().sprite = gm.block_sprites[sprite_count];
        block_level--;
    }

 
}
