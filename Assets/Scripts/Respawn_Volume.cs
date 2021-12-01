using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn_Volume : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject respawnPoint;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            MovePlayer();
        }
    }
    public void MovePlayer()
    {
        player.transform.position = respawnPoint.transform.position;
    }
}
