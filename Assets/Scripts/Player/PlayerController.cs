using CedarWoodSoftware;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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







    // Floats for movement direction
    float x, y;
    float facingDirection = 1;


    // Reference to the collisions script
    Collisions coll;
    // Reference to the rigidbody
    Rigidbody2D rb;
    // Vector 2 to store the new input in
    Vector2 movement;
    // Reference to the new control scheme
    Controls controls;
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
        // Set the gravity scale
        rb.gravityScale = gravityMultiplier;
    }

    void Update()
    {

    }

    void FixedUpdate()
    {
        // If not wall jumping or ledge grabbing move normally
        rb.velocity = new Vector2(x * movementSpeed, rb.velocity.y);
    }
    #endregion

    #region User Methods
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
        
    }

    public void OnDash(InputAction.CallbackContext context)
    {
       
    }

    public void OnWallGrab(InputAction.CallbackContext context)
    {
        
    }
    #endregion
}