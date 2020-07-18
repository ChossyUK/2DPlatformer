using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeGrab : MonoBehaviour
{
    #region Variables
    // X & Y position offsets for final ledge grab position
    [Header("Position Offsets")]
    [SerializeField] float xOffset = 1f;
    [SerializeField] float yOffset = 1.75f;

    // X & Y position offsets for player sprite
    [Header("Player Offsets")]
    [SerializeField] float playerXOffset = 0.1f;
    [SerializeField] float playerYOffset = 0.5f;

    // Ledge grab animation time
    [Header("Coroutine Time")]
    [SerializeField] float grabTime = 0.35f;

    // Bool for ledge grab
    public bool CanGrabLedge
    {
        get { return canGrabLedge; }
    }

    bool canGrabLedge = false;


    // Bool to take control of the basic ledge grab
    bool hijackControls = true;

    // Reference to the collisions script
    Collisions coll;
    // Reference to the better jumping script
    BetterJumping betterJumping;
    // Reference to the wall climb script
    WallClimb wallClimb;
    // Reference to the player controller script
    PlayerController playerController;
    // Reference to the rigidbody
    Rigidbody2D rb;
    // Vector to store the new position in
    Vector2 dir;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the betterJumping component
        betterJumping = GetComponent<BetterJumping>();
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        // Get the playerController component
        playerController = GetComponent<PlayerController>();
        // Get the wall climb component
        wallClimb = GetComponent<WallClimb>();
        // Set can grab ledge to false
        canGrabLedge = false;

        // Hijack the wall climb ledge grab
        wallClimb.disableLedgeGrab = hijackControls;
    }

    private void FixedUpdate()
    {
        // Check the ledge grab type locked to wall grab only
        if (coll.IsTouchingWall && !coll.IsTouchingLedge && wallClimb.wallGrab)
        {
            // Start the ledge grab
            StartLegdeGrab();
        }
    }
    #endregion

    #region User Methods
    public void StartLegdeGrab()
    {
        // Set the players current position moving the sprite up or down on the Y axis to match the animation
        playerController.transform.position = new Vector2(playerController.transform.position.x, playerController.transform.position.y - playerYOffset);

        // Zero out the players velocity
        rb.velocity = Vector2.zero;

        // Set ledge grab to true
        canGrabLedge = true;

        // Lock out the player input
        playerController.canMove = false;
        playerController.canJump = false;
        playerController.canFlip = false;

        // Set the gravity scale to zero 
        rb.gravityScale = 0;

        // Stop the player from freaking out if stuck in ledge grab
        StartCoroutine(Timer(grabTime));
    }

    public void FinishLedgeClimb()
    {
        // Check if we are facing right if so set the player transform to the new tile
        if (playerController.FacingRight)
            dir = new Vector2(playerController.FacingDirection * playerController.transform.position.x + xOffset, 
                playerController.transform.position.y + yOffset);

        // Check if we are facing left if so set the player transform to the new tile
        if (!playerController.FacingRight)
            dir = new Vector2(-playerController.FacingDirection * playerController.transform.position.x - xOffset, 
                playerController.transform.position.y + yOffset);


        // Teleport the player
        playerController.transform.position = dir;

        // Set ledge grab to false
        canGrabLedge = false;

        // Enable player input
        playerController.canMove = true;
        playerController.canJump = true;
        playerController.canFlip = true;

        // Reset the gravity scale
        rb.gravityScale = playerController.GravityMultiplier;
    }

    IEnumerator Timer(float time)
    {
        // Wait for a bit then finish the ledge climb
        yield return new WaitForSeconds(time);
        FinishLedgeClimb();
    }
    #endregion
}