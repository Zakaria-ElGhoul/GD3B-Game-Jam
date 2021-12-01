using System.Collections;
using System.Collections.Generic;
using UnityEngine.Animations;
using UnityEngine;
using UnityEngine.Events;

public class enemyAI : MonoBehaviour
{

    public Animator anim;
    BoxCollider2D m_Collider;
    public bool isFlipped;
    private SpriteRenderer mySpriteRenderer;
    public GameObject enemyparticle;
    public bool IsHit;
    public Respawn_Volume player;
    private Rigidbody2D rb;
    public UnityEvent DeathEvent;
    [SerializeField] private UnityEvent PlayerHit;

    void Start()
    {
        anim.SetBool("IsAlive", true);
        m_Collider = GetComponent<BoxCollider2D>();
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        if (isFlipped)
        {
            mySpriteRenderer.flipX = true;
            anim.SetBool("IsFlipped", true);
            Debug.Log("is Flipped");
        }
        else if (!isFlipped)
        {
            mySpriteRenderer.flipX = false;
            anim.SetBool("IsFlipped", false);
            Debug.Log("isn't Flipped");
        }
    }


    private void Update()
    {
             if(IsHit)                          
            StartCoroutine("Death");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            IsHit = true;
            DeathEvent.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHit.Invoke();
            player.MovePlayer();
        }
    }
    IEnumerator Death()
    {
        anim.SetBool("IsAlive", false);
        yield return new WaitForSeconds(1f);
        Instantiate(enemyparticle, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
