using UnityEngine;

public class BetterJumping : MonoBehaviour
{
    #region Variables
    // Float value to increase the ridgidbody by
    [SerializeField] float jumpFallMultiplier;

    // Reference to the rigidbody
    Rigidbody2D rb;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the rigidbody component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // If the rigidbody velocity is less than 0 apply the extra gravity 
        if (rb.velocity.y < 0)
        {
            // Increase the gravity when falling to shorten the jump arc
            rb.velocity += Vector2.up * Physics2D.gravity.y * jumpFallMultiplier * Time.deltaTime;
        }
    }
    #endregion

    #region User Methods

    #endregion
}