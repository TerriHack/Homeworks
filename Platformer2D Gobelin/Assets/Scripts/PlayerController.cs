using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Component")]
    public Rigidbody2D rb;
    public GroundCheck gc;
    public Animator anim;
    public PlayerData defaultData;
    
    [Header("Input Related")]
    public InputActionAsset inputAsset;
    public PlayerInput playerInput;
    private InputAction _jumpAction;
    private InputAction _horizontalMove;

    #region Private var
    private static readonly int IsGrounded = Animator.StringToHash("isGrounded");
    private Vector2 _playerPos;
    #endregion
    
    private void Start()
    {
        _playerPos = rb.position;
        anim.SetBool(IsGrounded, true);
        
        #region Input Related
        _jumpAction = playerInput.actions["Jump"];
        _jumpAction.Enable();
        _horizontalMove = playerInput.actions["Horizontal Movement"];
        _horizontalMove.Enable();
        #endregion
    }
    private void Update()
    {
        bool jump = _jumpAction.ReadValue<float>() != 0;
        if(jump) Jump();

        float _hMove = _horizontalMove.ReadValue<float>();
        if (_hMove > 0) LeftToRight();
        if (_hMove < 0) RightToLeft();
    }
    
    /// <summary>
    /// Applie a force to make the player jump et active l'animation state.
    /// </summary>
    private void Jump()
    {
        if (gc.isGrounded != true) return;
        anim.SetBool(IsGrounded, false);
        rb.AddForce(Vector2.up * defaultData.jumpForce, ForceMode2D.Impulse);
    }

    #region Horizontal Movement

    /// <summary>
    /// Applies a force to move the player left to right.
    /// </summary>
    private void LeftToRight()
    {
        rb.AddForce(new Vector2(_playerPos.x + defaultData.speed, _playerPos.y), ForceMode2D.Force);
    }
    
    /// <summary>
    /// Applies a force to move the player right to left.
    /// </summary>
    private void RightToLeft()
    {
        rb.AddForce(new Vector2(_playerPos.x - defaultData.speed, _playerPos.y), ForceMode2D.Force);
    }
    #endregion


}
