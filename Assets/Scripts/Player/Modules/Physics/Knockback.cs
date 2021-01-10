using System.Collections;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    #region Variables
    [SerializeField] float knockBackLength = 0.5f;
    [SerializeField] float knockBackForce = 15f;
    // Player component references
    PlayerController playerController;
    Rigidbody2D rb;

    public bool IsHurt
    {
        get { return isHurt; }
    }

    bool isHurt = false;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the player components
        playerController = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }
    #endregion

    #region User Methods
    public void DoKnockBack()
    {
        StartCoroutine(DisablePlayerMovement(knockBackLength));
        rb.velocity = new Vector2(-playerController.FacingDirection * knockBackForce, knockBackForce);
    }

    IEnumerator DisablePlayerMovement(float time)
    {
        // Disable player movement
        playerController.canMove = false;
        isHurt = true;
        // Wait the alloted time
        yield return new WaitForSeconds(time);
        // Enable player movement
        playerController.canMove = true;
        isHurt = false;
    }
    #endregion
}