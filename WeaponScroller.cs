using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScroller : MonoBehaviour
{
    //Doe script in player

    //--Wapen waardes--
    [Header("Wapen object dat moet draaien")]
    [SerializeField] private Transform sword;
    private float scroll;
    [Range(100, 2000)]
    [SerializeField] private float scrollAmount = 1000;

    //--player waardes--
    [Range(1, 100)]
    private float jumpStrenght = 10;
    private Rigidbody2D rb;


    //Gravity
    [Header("Object bij de voeten van de player om de grond te checken")]
    [SerializeField] private Transform groundCheck;

    [Header("Radius om de grond te checken")]
    [Range(0, 1)]
    [SerializeField] private float checkRadius = 0.25f;
    private bool isGrounded = false;
    [SerializeField] private LayerMask groundMask;

    //JumpStrenght
    [Header("Object bij de voeten van de player om de grond te checken")]
    [Range(0, 20)]
    private float maxJumpStrenght = 20;


    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);

        jumpStrenght = Mathf.PingPong(Time.time, maxJumpStrenght);

        MouseRollInput();
        MousePressInput();
    }

    void MouseRollInput()
    {
        if (Input.mouseScrollDelta.y > 0 && scroll > -110)
            scroll -= scrollAmount * Time.deltaTime;
        if (Input.mouseScrollDelta.y < 0 && scroll < 110)
            scroll += scrollAmount * Time.deltaTime;

        //Debug.Log(scroll);

        sword.rotation = Quaternion.Euler(0, 0, scroll);
    }

    void MousePressInput()
    {
        if(isGrounded == true && Input.GetMouseButton(2))
        {
            rb.velocity = sword.up * jumpStrenght;
        }
    }
}
