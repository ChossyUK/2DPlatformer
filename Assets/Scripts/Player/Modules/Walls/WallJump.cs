using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{
    #region Variables
    // Float to tweak wall jump height/direction
    [SerializeField] float divisionFactor = 1.35f;

    // Public bool for animator & player controller
    public bool WallJumped
    {
        get { return wallJumped; }
    }

    // Private bool for wall jumped
    bool wallJumped;
    // Reference to the collisions script
    Collisions coll;
    // Reference to the player controller script
    PlayerController playerController;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the playerController component
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Check & reset the wall jumped bool
        if (coll.IsGrounded || playerController.canMove)
            wallJumped = false;
    }
    #endregion

    #region User Methods
    public void DoWallJump()
    {
        // Stop & start the disable player movement coroutine
        StopCoroutine(DisableMovement(0));
        StartCoroutine(DisableMovement(0.2f));

        // Get a new vector 2 for the direction we want the player to jump in & normalize the value
        Vector2 wallDir = new Vector2(-playerController.FacingDirection, 0);
        // Do the wall jump
        playerController.Jump((Vector2.up / divisionFactor + wallDir));
        // Flip the player
        playerController.Flip();
        // Set wall jumped to true
        wallJumped = true;
    }

    IEnumerator DisableMovement(float time)
    {
        // Disable player movement
        playerController.canMove = false;
        playerController.disableMovement = true;
        // Wait the alloted time
        yield return new WaitForSeconds(time);
        // Enable player movement
        playerController.canMove = true;
        playerController.disableMovement = false;
    }
    #endregion
}