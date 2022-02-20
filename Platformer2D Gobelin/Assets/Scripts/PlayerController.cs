using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public enum PlayerState
{
    Idle = 0,
    Running = 1,
    Jumping = 2,
    Damaged = 3
}

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public JumpValues jumpValues;
    //public float speed = 10f;
    //public float jumpSpeed = 500f;
    public GroundCheck gc;
    public Animator anim;
    public SpriteRenderer ren;
    public UnityEvent OnJump;
    public PlayerState state = PlayerState.Idle;

    private float _timeMarker = -1f;

    private void Start()
    {
        anim.SetBool("isGrounded", true);
        jumpValues = Instantiate(jumpValues);
    }

    void Update()
    {
        Move();
        Jump();

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            anim.SetBool("isWalking", false);
        }

        jumpValues.FakeUpdate(Time.deltaTime);
        switch (state)
        {
            case PlayerState.Idle:
                //Logique
                break;
            case PlayerState.Running:
                //Logique
                break;
        }
    }

    void Move()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            ren.flipX = false;
            rb.velocity = new Vector2(jumpValues.speed, rb.velocity.y);
            anim.SetBool("isWalking", true);

        }
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            anim.SetBool("isWalking", true);
            ren.flipX = true;
            rb.velocity = new Vector2(-jumpValues.speed, rb.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.C) && gc.isGrounded == true)
        {
            anim.SetBool("isGrounded", false);
            rb.AddForce(Vector2.up * jumpValues.jumpforce, ForceMode2D.Impulse);
            OnJump.Invoke();
        }
    }

    public void SpawnJumpParticles() { }
}
