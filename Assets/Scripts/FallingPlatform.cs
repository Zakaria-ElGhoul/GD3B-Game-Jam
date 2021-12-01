using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FallingPlatform : MonoBehaviour

{
    public Rigidbody2D rb;
    public Tilemap platformTile;
    public Color startColor;
    public Color endColor;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine("FallDown");
        }
    }

    IEnumerator FallDown()
    {
       yield return new WaitForSeconds(1f);
        rb.isKinematic = false;
        platformTile.color = Color.Lerp(startColor, endColor, 0.1f);

        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
