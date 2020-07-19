using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbableObject : MonoBehaviour
{
    #region Variables
    // Ladder climbing speed
    [SerializeField] float climbingSpeed = 4f;
    // Reference to the hidden platform box collider
    [SerializeField] BoxCollider2D platformBoxCollider;
    // Reference to the hidden platform effector collider
    [SerializeField] PlatformEffector2D platformEffector;
    // Bool for if is the object is a ladder
    [SerializeField] bool isLadder = true;
    // Bool to lock the player to the ladder
    [SerializeField] bool lockToLadder = true;

    // Reference to the player controller script
    PlayerController playerController;
    // Reference to the collisions script
    Collisions coll;
    // Reference to the animator
    Animator animator;
    // Reference to the rigidbody
    Rigidbody2D rb;
    // Bool for climbing
    public static bool IsClimbing;
    #endregion

    #region Unity Base Methods
    void OnEnable()
    {
        // Get the player controller component
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        // Get the animator component
        animator = playerController.GetComponentInChildren<Animator>();
        // Get the collisions component
        coll = playerController.GetComponent<Collisions>();
        // Get the rigidbody
        rb = playerController.GetComponent<Rigidbody2D>();
    }

    private void OnDisable()
    {
        // Null all the components
        playerController = null;
        animator = null;
        coll = null;
        rb = null;
    }

    void FixedUpdate()
    {
        // Only check if is climbing is set to true so not to mess with any other physics
        if (IsClimbing)
            Climbing();
    }

    void OnTriggerStay2D(Collider2D other)
    {
        // Get the player by tag
        if (other.tag == "Player")
        {
            // Check if walking past the object or stoped by the object and is on the ground if walking set it so you are not climbing
            if ((playerController.X > 0.1f || playerController.X < -0.1f) && coll.IsGrounded)
            {
                // Set the animator speed
                animator.speed = 1;

                // Set is climbing to false
                IsClimbing = false;
            }
            else
            {
                // Set is climbing to true
                IsClimbing = true;

                // Check if object is a ladder
                if (isLadder)
                {
                    // Disable the platform colliders
                    platformBoxCollider.enabled = false;
                    platformEffector.enabled = false;
                }
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            // Set is climbing to false
            IsClimbing = false;

            // Set the animator speed
            animator.speed = 1;

            // Check if object is a ladder
            if (isLadder)
            {
                // Enable the platform colliders
                platformBoxCollider.enabled = true;
                platformEffector.enabled = true;
            }

            // Unlock the rigidbody constraints
            if (lockToLadder)
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        }
    }
    #endregion

    #region User Methods
    void Climbing()
    {
        // If climbing the ladder disable the gravity and move up or down
        if (IsClimbing)
        {
            // Check if object is a ladder
            if (isLadder)
            {
                // Get the input on the Y axis and set the animator speed
                if (Mathf.Abs(playerController.Y) > 0.15f)
                    // Set the animator speed
                    animator.speed = 1;
                else
                    // Set the animator speed to 0
                    animator.speed = 0;
            }
            else
            {
                // Get the input on the X and Y axis and set the animator speed
                if (Mathf.Abs(playerController.Y) > 0.15f || Mathf.Abs(playerController.X) > 0.15f)
                    // Set the animator speed
                    animator.speed = 1;
                else
                    // Set the animator speed
                    animator.speed = 0;
            }


            // Lock the rigidbody constraints
            if (lockToLadder)
            {
                // Set the player position to the middle of the ladder
                playerController.transform.position = new Vector2(transform.position.x, playerController.transform.position.y);
                // Freeze the rigidbody x position and rotation
                rb.constraints = RigidbodyConstraints2D.FreezePositionX;
                rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            }

            // Move the player
            rb.velocity = new Vector2(rb.velocity.x, playerController.Y * climbingSpeed);
            // Set the gravity scale to 0
            rb.gravityScale = 0;
        }
        else
        {
            // If not climbing reset the gravity scale
            rb.gravityScale = playerController.GravityMultiplier;
        }
    }
    #endregion
}