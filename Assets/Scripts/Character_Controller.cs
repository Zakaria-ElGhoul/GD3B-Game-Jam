using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    //Doe script in player

    //--Wapen waardes--
    [Header("Wapen object dat moet draaien")]
    [SerializeField] private Transform sword;
    private float scroll;
    [SerializeField] private float scrollStrenght;
        
    [Range(100, 2000)]
    [SerializeField] private float scrollAmount = 1000;

    //--player waardes--
    [Range(1, 100)]
    private float jumpStrenght = 5;
    private Rigidbody2D rb;
    [SerializeField]private SpriteRenderer playerSprite;

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
    [SerializeField] private float maxJumpStrenght = 10;
    [SerializeField] private float PingPongSpeed;

    [Header("Object bij de voeten van de player om de grond te checken")]
    [SerializeField] private Slider slider;
    [SerializeField] public Image slider1Fill;

    [Header("Unity Events")]
    [SerializeField]private UnityEvent jumpEvent;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);

        jumpStrenght = Mathf.PingPong(Time.time * PingPongSpeed, maxJumpStrenght);

        UpdateUI();
        FlipSprite();
        MouseRollInput();
        MousePressInput();
    }

    void MouseRollInput()
    {
        if (Input.mouseScrollDelta.y > 0 && scroll > -110)
            scroll -= scrollAmount * scrollStrenght  *  Time.deltaTime;
        if (Input.mouseScrollDelta.y < 0 && scroll < 110)
            scroll += scrollAmount * scrollStrenght * Time.deltaTime;
        sword.rotation = Quaternion.Euler(0, 0, scroll);

        Debug.Log(Input.mouseScrollDelta.y);
    }

    void MousePressInput()
    {
        if(isGrounded == true && Input.GetMouseButtonDown(2))
        {
            rb.velocity = sword.up * jumpStrenght;
            jumpEvent.Invoke();
        }
    }

    void UpdateUI()
    {
        slider.value = jumpStrenght / maxJumpStrenght;
    }

    public void OnSliderChange()
    {
        slider1Fill.color = Color.Lerp(Color.green, Color.red, slider.value);
    }

    public void FlipSprite()
    {
        if(scroll > 0.1f)
        {
            playerSprite.flipX = true;
        }
        else
        {
            playerSprite.flipX = false;
        }
    }

}
