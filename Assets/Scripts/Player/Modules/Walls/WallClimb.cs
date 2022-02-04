using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClimb : MonoBehaviour
{
    #region Variables
    // Float for wall climb speed
    [SerializeField] float wallClimbSpeed;
    [Header("Position Offsets")]
    // Offsets to teleport the player to the next tile
    [SerializeField] float xOffset = 1f;
    [SerializeField] float yOffset = 2f;
    [Header("Joystick Deadzone")]
    // Float for switching the wall climbing/grabbing bools for the animator
    [SerializeField] float deadZone = 0.2f;
    // Bool for wall grab 
    [HideInInspector]
    public bool wallGrab;

    // Bool to disable basic ledge climb if using the ledge climb module
    [HideInInspector]
    public bool disableLedgeGrab = false;

    // Wall grabbing bools for the animator
    public bool IsWallGrabbing
    {
        get { return isWallGrabbing; }
    }

    bool isWallGrabbing = false;

    // Wall climbing bools for the animator
    public bool IsWallClimbing
    {
        get { return isWallClimbing; }
        set { isWallClimbing = value; }
    }

    bool isWallClimbing = false;

    // Reference to the collisions script
    Collisions coll;
    // Reference to the player controller script
    PlayerController playerController;
    // Reference to the rigidbody
    Rigidbody2D rb;
    // Direction to store the new transform in
    Vector2 dir;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        // Get the playerController component
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Reset wall climbing to false if on the ground
        if (coll.IsGrounded)
        {
            // Set wall grab to false
            wallGrab = false;
        }

        // Check if we are wall grabbing
        CheckWallGrab();
    }

    void FixedUpdate()
    {
        // Check if we are using the ledge grab code if not use this code
        if (!disableLedgeGrab)
        {
            // Check if we are touching the wall but not touching a ledge and are wall grabbing
            if (coll.IsTouchingWall && !coll.IsTouchingLedge && wallGrab)
            {
                // Do the basic ledge grab
                BasicLedgeGrab();
            }
        }
    }
    #endregion

    #region User Methods
    public void BasicLedgeGrab()
    {
        // Zero the players velocity
        rb.velocity = Vector2.zero;

        // Check if we are facing right if so set the player transform to the new tile
        if (playerController.FacingRight)
            dir = new Vector2(playerController.FacingDirection * playerController.transform.position.x
                + xOffset, playerController.transform.position.y + yOffset);

        // Check if we are facing left if so set the player transform to the new tile
        if (!playerController.FacingRight)
            dir = new Vector2(-playerController.FacingDirection * playerController.transform.position.x
                - xOffset, playerController.transform.position.y + yOffset);

        // Teleport the player
        playerController.transform.position = dir;
    }

    public void CheckWallGrab()
    {
        // Check if the play can move if not return
        if (!playerController.canMove)
            return;

        // Set the animator bools to false when on the ground
        if (coll.IsGrounded)
        {
            isWallGrabbing = false;
            isWallClimbing = false;
        }

        if (!coll.IsGrounded && !coll.IsTouchingWall)
        {
            isWallGrabbing = false;
            isWallClimbing = false;
        }

        // Check if we are wall grabbing
        if (wallGrab && !coll.IsGrounded && coll.IsTouchingWall && playerController.canMove)
        {
            // Set the gravity scale to 0
            rb.gravityScale = 0;

            // Set the Y velocity to 0
            rb.velocity = new Vector2(rb.velocity.x, 0);

            // Switch between bools depending on the player Y input axis
            if (playerController.Y < -deadZone || playerController.Y > deadZone)
            {
                isWallGrabbing = false;
                isWallClimbing = true;
                playerController.canJump = false;
            }
            else
            {
                isWallGrabbing = true;
                isWallClimbing = false;
                playerController.canJump = true;
            }

            // Move the player via the left sticks Y position
            rb.velocity = new Vector2(rb.velocity.x, playerController.Y * wallClimbSpeed);
        }
        else
        {
            // Reset the gravity scale
            rb.gravityScale = playerController.GravityMultiplier;
            isWallGrabbing = false;
        }
    }
    #endregion
}