using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class sword : MonoBehaviour
{
    public enemyAI enemy;
    public UnityEvent EnemyDeathEvent;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyDeathEvent.Invoke();
            enemy.IsHit = true;
        }
    }
}
