﻿using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour, Controls.IPlayer1Actions
{
    #region Variables
    [Header("Player Setup")]
    // Player movement speed
    public float movementSpeed;
    // Player jump height
    [SerializeField] float jumpForce;
    // Gravity multiplier
    [SerializeField] float gravityMultiplier;
    // Jump multiplyer for variable jump height
    [SerializeField] float jumpMultiplier = 0.5f;

    // Public getters
    public float GravityMultiplier
    {
        get { return gravityMultiplier; }
    }

    public float Y
    {
        get { return y; }
    }

    public float X
    {
        get { return x; }
    }

    public float FacingDirection
    {
        get { return facingDirection; }
    }

    public bool FacingRight
    {
        get { return facingRight; }
    }

    public bool IsJumping
    {
        get { return isJumping; }
    }

    // Floats for movement direction
    float x, y;
    float facingDirection = 1;

    // Bools to control the player
    public bool canMove = true;
    [HideInInspector]
    public bool canFlip = true;
    [HideInInspector]
    public bool canJump = true;
    bool isJumping = false;
    bool doubleJumped = false;
    bool facingRight = true;

    // Reference to the collisions script
    Collisions coll;
    // Reference to the rigidbody
    Rigidbody2D rb;
    // Vector 2 to store the new input in
    Vector2 movement;
    // Reference to the new control scheme
    Controls controls;
    // Reference to the dash script
    Dash dash;

    // Reference to the wall climb script
    WallClimb wallClimb;
    #endregion

    #region Unity Base Methods
    void Awake()
    {
        // Create a new control map
        controls = new Controls();
        // Get the control callbacks to use the new action map
        controls.Player1.SetCallbacks(this);
    }

    void OnEnable()
    {
        // Enable the new control scheme
        controls.Player1.Enable();
    }

    void OnDisable()
    {
        // Disable the new control scheme
        controls.Player1.Disable();
    }

    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the rigidbody the script is attached to
        rb = GetComponent<Rigidbody2D>();
        // Get the dash component
        dash = GetComponent<Dash>();
        // Get the wall climb component
        wallClimb = GetComponent<WallClimb>();

        // Set the gravity scale
        rb.gravityScale = gravityMultiplier;
    }

    void Update()
    {
        CheckMovement();
    }

    void FixedUpdate()
    {
        // If not wall jumping or ledge grabbing move normally
        rb.velocity = new Vector2(x * movementSpeed, rb.velocity.y);
    }
    #endregion

    #region User Methods
    void CheckMovement()
    {
        // Check if we are touching the ground
        if (coll.IsGrounded)
        {
            // Reset the is jumping bool
            isJumping = false;

            // Reset the is double jumping bool
            doubleJumped = false;
        }

        // Flip the player according to direction
        if (!facingRight && x > 0.1f || facingRight && x < -0.1f)
        {
            // call the flip method
            Flip();
        }
    }


    public void Flip()
    {
        // Check if flip is enabled
        if (canFlip)
        {
            // Flip the facing direction
            facingDirection *= -1;
            // Flip between left and right
            facingRight = !facingRight;
            // Flip the player sprite 
            transform.Rotate(0f, 180f, 0f);
        }
    }

    public void Jump(Vector2 dir)
    {
        // Zero out the Y velocity
        rb.velocity = new Vector2(rb.velocity.x, 0);

        // make the player jump
        rb.velocity += dir * jumpForce;
    }

    void SetJumpBool()
    {
        // Set the jump bool to true
        isJumping = true;
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        // Get the input from the new control scheme
        movement = controls.Player1.Movement.ReadValue<Vector2>();

        // Set the movement direction floats
        x = movement.x;
        y = movement.y;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if(canJump)
        {
            // Check if button pressed
            if (context.performed)
            {
                Invoke("SetJumpBool", 0.1f);

                // Jump
                if (coll.IsGrounded)
                {
                    Jump(Vector2.up);
                }

                // Double Jump
                if (!coll.IsGrounded && !doubleJumped)
                {
                    Jump(Vector2.up);
                    doubleJumped = true;
                }
            }

            // Check if button released
            if (context.canceled)
            {
                // Set the jump velocity depending on how long the button is held down
                rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * jumpMultiplier);
            }
        }
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        // Check if button pressed
        if (context.performed)
        {
            // Start dashing
            dash.StartDash();
        }
    }

    public void OnWallGrab(InputAction.CallbackContext context)
    {
        // Check if button pressed
        if (context.performed)
        {
            // Start wall grab
            wallClimb.wallGrab = true;
        }

        // Check if button released
        if (context.canceled)
        {
            // Stop wall grab
            wallClimb.wallGrab = false;
        }
    }
    #endregion
}