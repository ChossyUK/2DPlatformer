using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSlide : MonoBehaviour
{
    #region Variables
    // Float for wall slide speed
    [SerializeField] float wallSlideSpeed = 4;

    // Bool for is wall sliding       
    public bool IsWallSliding
    {
        get { return isWallSliding; }
        set { isWallSliding = value; }
    }

    bool isWallSliding;

    // Bool to disable wall slide & give control to the ledge grab script
    [HideInInspector]
    public bool disableWallSliding = false;
    // Reference to the collisions script
    Collisions coll;
    // Reference to the wall climb script
    WallClimb wallClimb;
    // Reference to the player controller script
    PlayerController playerController;
    // Reference to the rigidbody
    Rigidbody2D rb;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the wall climb component
        wallClimb = GetComponent<WallClimb>();

        // Get the collisions component
        coll = GetComponent<Collisions>();

        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();

        // Get the playerController component
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Reset wall sliding to false if on the ground
        if (coll.IsGrounded)
            isWallSliding = false;

        // Check to see if we can wall slide
        if (coll.IsTouchingWall && !coll.IsGrounded)
        {
            // Check if control is enabled
            if (!disableWallSliding)
            {
                // Check for input & we are not wall grabbing
                if (playerController.X != 0 && !wallClimb.wallGrab)
                {
                    // Set wall slide to true
                    isWallSliding = true;
                    // Do the wall slide
                    DoWallSlide();
                }
                else
                {
                    // Set wall slide to false 
                    isWallSliding = false;
                }
            }
        }
    }
    #endregion

    #region User Methods
    public void DoWallSlide()
    {
        // Do nothing if the player can't move
        if (!playerController.canMove)
            return;

        // Check the player is pressing against a wall
        if ((playerController.X > 0.5f || playerController.X < -0.5f && coll.IsTouchingWall))
        {
            // Set the Y velocity to the wall slide speed
            rb.velocity = new Vector2(playerController.X, -wallSlideSpeed);
        }
    }
    #endregion
}