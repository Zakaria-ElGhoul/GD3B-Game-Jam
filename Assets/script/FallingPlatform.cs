﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingPlatform : MonoBehaviour

{
    public Rigidbody2D rb;
    public SpriteRenderer platformSprite;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("fallDown");
        }
    }

    IEnumerator fallDown()
    {
       yield return new WaitForSeconds(2f);
        rb.isKinematic = false;
        platformSprite.color = Color.Lerp(Color.white, Color.black, 4f);
        yield return new WaitForSeconds(10f);
        Destroy(this.gameObject);
    }
}