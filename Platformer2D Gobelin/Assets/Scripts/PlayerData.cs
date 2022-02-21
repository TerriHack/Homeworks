using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Player Data", order = 1)]

public class PlayerData : ScriptableObject
{
    [Header("Name")]
    public string dataName;
    
    [Header("Forces")]
    [Tooltip("The Jump Force cannot exceed 100")]
    public int jumpForce;
    [Tooltip("The Speed cannot exceed 100")]
    public int speed;
    
    [Header("Countdown")]
    public float jumpBufferCountdown;
    public float coyoteTimeCountdown;
}
