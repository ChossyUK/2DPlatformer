using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    #region Variables
    // Float value to increase the ridgidbody by
    [SerializeField] float jumpFallMultiplier;

    public float maxFallSpeed = 20f;

    public float animationThreshold = 2f;

    public bool IsFalling;
    // Reference to the rigidbody
    Rigidbody2D rb;
    Slopes slopes;
    WallSlide wallSlide;
    WallClimb wallClimb;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
        slopes = GetComponent<Slopes>();
        wallSlide = GetComponent<WallSlide>();
        wallClimb = GetComponent<WallClimb>();
    }

    void Update()
    {
        // If the rigidbody velocity is less than 0 apply the extra gravity 
        if (rb.velocity.y < -animationThreshold && !slopes.OnSlope && !ClimbableObject.IsClimbing && !wallSlide.IsWallSliding && !wallClimb.IsWallClimbing)
        {
            // Increase the gravity when falling to shorten the jump arc
            rb.velocity += Vector2.up * Physics2D.gravity.y * jumpFallMultiplier * Time.deltaTime;

            // Limit the maximum fall velocity
            if (rb.velocity.magnitude > maxFallSpeed)
                rb.velocity = Vector2.ClampMagnitude(rb.velocity, maxFallSpeed);

            IsFalling = true;
        }
        else
        {
            IsFalling = false;
        }
    }
    #endregion

    #region User Methods

    #endregion
}