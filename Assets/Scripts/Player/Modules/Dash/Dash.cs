using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    #region Variables
    // Float for dash speed
    [SerializeField] float dashSpeed = 10f;
    // Float for dash length
    [SerializeField] float dashLength = 0.5f;
    // Float for dash cooldown counter
    [SerializeField] float dashCoolDown = 1f;
    // Distance between images for the after image effect
    [SerializeField] float distanceBetweenDash = 0.5f;
    [Range(1, 3)]
    // Shorten the jump distance if disable gravity enabled
    [SerializeField] float jumpDivider = 2f;
    // Bool to disable using the object pool if you want an animation not the after image effect
    [SerializeField] bool useObjectPool = true;
    // Bool to disable gravity when jumping
    [SerializeField] bool gravityJump = true;
    // Bool to disable better jumping
    [SerializeField] bool disableBetterJump = false;

    // Bool for is dashing
    public bool IsDashing
    {
        get { return isDashing; }
    }

    bool isDashing = false;

    // Floats for dash counter & cool down timer
    float dashCounter, dashCoolDownCounter;
    // Float to store original move speed
    float activeMoveSpeed;
    // Float to store the after image effect image position
    float lastDashXPosition;
    // Reference to the better jumping script
    BetterJumping betterJumping;
    // Reference to the player controller script
    PlayerController playerController;
    // Reference to the rigidbody
    Rigidbody2D rb;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the betterJumping component
        betterJumping = GetComponent<BetterJumping>();
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        // Get the playerController component
        playerController = GetComponent<PlayerController>();

        // Get & set the current players move speed
        activeMoveSpeed = playerController.movementSpeed;
    }

    void Update()
    {
        CheckDash();
    }
    #endregion

    #region User Methods
    public void StartDash()
    {
        // Check the dash & cool down timers are below 0
        if (dashCoolDownCounter <= 0 && dashCounter <= 0)
        {
            // Set the players movespeed to the dash speed
            playerController.movementSpeed = dashSpeed;
            // Set the dash timer length
            dashCounter = dashLength;

            // If using the object pool instance an after effect image
            if (useObjectPool)
            {
                // Get an image from the object pool
                ObjectPool.Instance.GetFromPool();
                // Set the last dash position
                lastDashXPosition = transform.position.x;
            }
        }
    }

    void CheckDash()
    {
        if (dashCounter > 0 && playerController.X != 0)
        {
            // Set is dashing bool to true
            isDashing = true;

            if (playerController.X == 0)
            {
                dashCounter = 0;

                playerController.movementSpeed = activeMoveSpeed;
                // Set is dashing bool to false
                isDashing = false;
            }

            // Check & disable better jump
            if (disableBetterJump)
            {
                betterJumping.enabled = false;
            }

            // Check & disable gravity
            if (gravityJump)
            {
                // Shorten the jump distance if jumping
                if (playerController.IsJumping)
                {
                    rb.gravityScale = 0;
                    dashCounter -= Time.deltaTime * jumpDivider;
                }
                else
                {
                    dashCounter -= Time.deltaTime;
                    rb.gravityScale = playerController.GravityMultiplier;
                }
            }
            else
            {
                // Start counting down the dash timer
                dashCounter -= Time.deltaTime;
            }

            // If using the object pool instance an after effect image
            if (useObjectPool)
            {
                // Check the distance beteen after effect images & instance a new one
                if (Mathf.Abs(transform.position.x - lastDashXPosition) > distanceBetweenDash)
                {
                    // Get an image from the object pool
                    ObjectPool.Instance.GetFromPool();
                    // Set the last dash position
                    lastDashXPosition = transform.position.x;
                }
            }


            // Check if the dash timer is below 0
            if (dashCounter < 0)
            {
                // Reset the players movespeed
                playerController.movementSpeed = activeMoveSpeed;
                // Start the cool down timer
                dashCoolDownCounter = dashCoolDown;
                // Set is dashing bool to false
                isDashing = false;
                // Enable gravity
                rb.gravityScale = playerController.GravityMultiplier;

                // Check & enable better jumping
                if (disableBetterJump)
                {
                    betterJumping.enabled = true;
                }
            }
        }



        // Start counting down the dash cooldown timer
        if (dashCoolDownCounter > 0)
        {
            dashCoolDownCounter -= Time.deltaTime;
        }
    }
    #endregion
}