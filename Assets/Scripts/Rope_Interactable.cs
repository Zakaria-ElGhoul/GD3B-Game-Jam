using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope_Interactable : MonoBehaviour
{
    [SerializeField] private bool isTouched;

    private void Update()
    {
        if(isTouched == true)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            bool isTouched = true;
        }    
    }
}
