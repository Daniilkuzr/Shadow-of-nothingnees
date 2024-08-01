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
    public bool keyJerk;
    public bool faceRight = true;
    public float jerkMove;

    public bool comleteJerk;
    public float jerkCoolDown;
    public float stertTimerCooldown=0;



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

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Jerk();
        }
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
        if(Input.GetKeyDown(KeyCode.W) && onGround)
        {
            //rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            rb.AddForce(Vector2.up * jumpForce);
        }
    }

    public bool onGround;
    public Transform GruondCheck;
    public float checkRadius;
    public LayerMask Ground;

    void CheckigGround()
    {
        onGround = Physics2D.OverlapCircle(GruondCheck.position, checkRadius, Ground);
        anim.SetBool("onGround", onGround);
    }

    void Jerk()
    {
        anim.SetTrigger("keyJerk");
        if (faceRight)
        {
            rb.AddForce(Vector2.right * jerkMove);
        }
        else if(!faceRight)
        {
            rb.AddForce(Vector2.left * jerkMove);
        }

    }


}
