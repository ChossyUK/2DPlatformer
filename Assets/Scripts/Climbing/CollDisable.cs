using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollDisable : MonoBehaviour
{
    #region Variables
    // Reference to the hidden platform box collider
    [SerializeField] BoxCollider2D boxCollider;
    // How far the player has to press before disabling the collider
    float deadZone = 0.5f;
    // Reference to the player controller script
    PlayerController playerController;
    #endregion

    #region Unity Base Methods
    void OnEnable()
    {
        // Get the playerController component
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Disable the collider
            if (playerController.Y < -deadZone)
                boxCollider.enabled = false;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            // Enable the collider
            boxCollider.enabled = true;
        }
    }

    #endregion
}