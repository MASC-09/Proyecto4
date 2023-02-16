using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveJoystick : MonoBehaviour
{
    private float horizontalMove = 0f;
    public Joystick joystick;

    public float runSpeedHorizontal = 2;
    
    public float walkSpeed = 2;
    public float runSpeed = 1.25f;
    public float jumpSpeed = 3;
    Rigidbody2D rb; //this is the player. Gets assigned on the Unity
    SpriteRenderer sr;
    public Animator animator;

    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJumpMultiplier = 1f;
    // Start is called before the first frame update

    private bool canDoubleJump = false;
    public float doubleJumpSpeed = 2.5f;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }
    private void FixedUpdate()
    {
        horizontalMove = joystick.Horizontal * runSpeedHorizontal;
        transform.position += new Vector3(horizontalMove, 0, 0) * Time.deltaTime * runSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Mayor a 0 se mueve a la derecha
        //Menor a 0 se mueve a la izquierda
        if (horizontalMove > 0)
        {
            rb.velocity = new Vector2(runSpeed, rb.velocity.y);
            sr.flipX = false;
        }
        else if (horizontalMove < 0)
        {
            rb.velocity = new Vector2(-runSpeed, rb.velocity.y);
            sr.flipX = true;
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        //if (betterJump)
        //{
        //    if (rb.velocity.y < 0)
        //    {
        //        rb.velocity += Vector2.up * Physics2D.gravity.y * fallMultiplier * Time.deltaTime;
        //    }
        //    if (rb.velocity.y > 0 && !Input.GetKey("space"))
        //    {
        //        rb.velocity += Vector2.up * Physics2D.gravity.y * lowJumpMultiplier * Time.deltaTime;
        //    }
        //}


        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }
        else if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            animator.SetBool("DoubleJump", false);
            animator.SetBool("Falling", false);

            if (rb.velocity.y < 0) //if is less than 0 then it is falling
            {
                animator.SetBool("Falling", true);
            }
            else if (rb.velocity.y > 0) //it is rising
            {
                animator.SetBool("Falling", true);
            }

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

    public void Jump()
    {
        //salto sencillo
        if (CheckGround.isGrounded)
        {
            canDoubleJump = true;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
        //double jump
        else
        {
            //if (Input.GetKeyDown("space")) //when you press down  the key 
            //{
            if (canDoubleJump)
            {
                animator.SetBool("DoubleJump", true);
                rb.velocity = new Vector2(rb.velocity.x, doubleJumpSpeed);
                canDoubleJump = false;
            }
            //}
        }
    }
}
