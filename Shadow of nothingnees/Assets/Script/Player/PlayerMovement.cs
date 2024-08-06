using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public Vector2 moveVector;
    public float speed;
    public Animator anim;
    public SpriteRenderer sr;

    public bool faceRight = true;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    
    void Update()
    {
        walk();
        Reflect();
        Jump();
        CheckigGround();
        Fight();
    }

    void walk()
    {
        moveVector.x = Input.GetAxis("Horizontal")*speed;
        anim.SetFloat("moveX", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x, rb.velocity.y);
    }
    void Reflect()
    {
        if ((moveVector.x > 0 && !faceRight) || (moveVector.x < 0 && faceRight))
        {
            transform.localScale *= new Vector2(-1, 1);
            faceRight = !faceRight;
        }
    }

    public float jumpForce = 7f;

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.W) && onGround)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            anim.SetBool("onGround", onGround);
            rb.AddForce(Vector2.up * jumpForce);
        }
        else anim.SetBool("onGround", onGround);
    }

    public bool onGround;
    public Transform GruondCheck;
    public float checkRadius = 0.3f;
    public LayerMask Ground;

    void CheckigGround()
    {
        onGround = Physics2D.OverlapCircle(GruondCheck.position, checkRadius, Ground);
    }

    void Fight()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetTrigger("Fight");
        }
        
    }
}
