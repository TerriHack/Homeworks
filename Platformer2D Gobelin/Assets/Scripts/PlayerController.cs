using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 10f;
    public float jumpSpeed = 500f;
    public GroundCheck gc;
    public Animator anim;
    public SpriteRenderer ren;

    void Update()
    {

        Move();
        Jump();

        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isWalking", false);
        }
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            ren.flipX = false;
            rb.velocity = new Vector2(speed, rb.velocity.y);
            anim.SetBool("isWalking", true);

        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true);
            ren.flipX = true;
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C) && gc.isGrounded == true)
        {
            Debug.Log("ui");
            rb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
        }
    }
}
