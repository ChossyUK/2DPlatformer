using UnityEngine;

public class Slopes : MonoBehaviour
{
    #region Variables
    [Header("Slope Info")]
    [SerializeField] Transform slopeCheckPos;
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] PhysicsMaterial2D noFriction, slopeFriction;
    [SerializeField] float newAnimationThreshold = 10f;
    [HideInInspector] public bool OnSlope = false;

    RaycastHit2D hit;
    Vector3 pos;

    float oldAnimationThreshold;

    // Reference to the player components
    PlayerController playerController;
    Collisions coll;
    Rigidbody2D rb;
    BetterJumping betterJumping;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the player components 
        playerController = GetComponent<PlayerController>();
        coll = GetComponent<Collisions>();
        rb = GetComponent<Rigidbody2D>();
        betterJumping = GetComponent<BetterJumping>();
        oldAnimationThreshold = betterJumping.animationThreshold;
    }

    void FixedUpdate()
    {
        if (OnSlope)
            betterJumping.animationThreshold = newAnimationThreshold;
        else
            betterJumping.animationThreshold = oldAnimationThreshold;

        CheckSlope();
    }
    #endregion

    #region User Methods
    void CheckSlope()
    {
        if (playerController.IsJumping)
        {
            rb.sharedMaterial = noFriction;
            betterJumping.animationThreshold = oldAnimationThreshold;
            OnSlope = false;
        }

        if (coll.IsGrounded)
        {
            // Fire the ray
            hit = Physics2D.Raycast(slopeCheckPos.position, Vector2.down, 2f, whatIsGround);

            // Check the ray value to see if we are on a slope
            if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f)
            {
                // Set the bool
                OnSlope = true;

                // Limit the player velocity               
                if (rb.velocity.y < 0)
                {
                    rb.velocity = Vector2.ClampMagnitude(rb.velocity, playerController.movementSpeed);
                }

                // Apply the correct friction to the rigidbody
                if (playerController.X == 0 && !playerController.IsJumping)
                    rb.sharedMaterial = slopeFriction;
                else
                    rb.sharedMaterial = noFriction;

                //Move Player down to compensate for the slope below them
                pos = playerController.transform.position;
                pos.y += -hit.normal.y * Mathf.Abs(rb.velocity.y) * Time.fixedDeltaTime * (rb.velocity.y < 0 ? 1 : -1);
                playerController.transform.position = pos;
            }
            else
            {
                // Set the bool
                OnSlope = false;
            }
        }
    }
    #endregion
}