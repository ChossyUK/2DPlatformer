using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoyoteTime : MonoBehaviour
{
    #region Variables
    // Jump time after the player has left an Platform
    [SerializeField] float coyoteTime = 0.2f;

    // Timer to check for the jump
    public float CoyoteTimer
    {
        get { return coyoteTimer; }
    }

    float coyoteTimer;

    // Reference to the collisions script
    Collisions coll;
    // Reference to the player controller script
    PlayerController playerController;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the playerController component
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Check if grounded
        if (coll.IsGrounded)
        {
            // Set the timer time
            coyoteTimer = coyoteTime;
        }
        // Check if touching wall
        else if (coll.IsTouchingWall)
        {
            // Set the timer time
            coyoteTimer = coyoteTime;
        }
        // Check if climbing
        else if (playerController.IsClimbing || playerController.HorizontalClimbing)
        {
            // Set the timer time
            coyoteTimer = coyoteTime;
        }
        //Check if double jumped
        else if (!coll.IsGrounded && !playerController.DoubleJumped)
        {
            // Set the timer time
            coyoteTimer = coyoteTime;
        }
        else
        {
            // Countdown the time
            coyoteTimer -= Time.deltaTime;
        }
    }
    #endregion

    #region User Methods

    #endregion
}