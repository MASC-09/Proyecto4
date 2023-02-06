using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float walkSpeed = 2;
    public float runSpeed = 3; 
    public float jumpSpeed = 3;
    Rigidbody2D rb; //this is the player. Gets assigned on the Unity
    SpriteRenderer sr;
    public Animator animator;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();    
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
            sr.flipX = false;
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
            sr.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        if (betterJump)
        {
            if(rb.velocity.y < 0)
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
            }
            if(rb.velocity.y > 0 && !Input.GetKey("Space"))
            {
                rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
            }
        }


        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed); 
        }
        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            if (rb.velocity.x == 0)
            {
                animator.SetBool("Run", false);
            }
            else
            {
                animator.SetBool("Run", true);
            }
        }
    }

    void isRunning()
    {


    }
}
