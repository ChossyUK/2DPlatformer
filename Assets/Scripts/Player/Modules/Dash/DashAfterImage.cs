using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashAfterImage : MonoBehaviour
{
    #region Variables
    // Float for the amount of time you want the image to be active
    [SerializeField] float activeTime = 0.25f;

    // Float for initial alpha value
    [SerializeField] float setAlpha = 1;

    // Float for alpha value multiplier
    [SerializeField] float alphaMultiplier = 0.85f;

    // Float for timer
    float timeActivated;

    // Float for alpha value
    float alpha;

    // Reference to the player controller script
    Transform playerController;

    // Reference to the sprite renderer
    SpriteRenderer sR;

    // Reference to the player sprite renderer
    SpriteRenderer playerSr;

    // Colour to change the alpha
    Color color;
    #endregion

    #region Unity Base Methods
    void OnEnable()
    {
        // Get the player controller
        playerController = GameObject.FindGameObjectWithTag("Player").transform;

        // Get the sprite renderer
        sR = GetComponent<SpriteRenderer>();

        // Get the player sprite renderer
        playerSr = playerController.GetComponentInChildren<SpriteRenderer>();

        // Set the initial game object alpha value
        alpha = setAlpha;

        // Set the sprite renderer to the player sprite renderer
        sR.sprite = playerSr.sprite;

        // Set the game objects position & rotation
        transform.position = playerController.transform.position;
        transform.rotation = playerController.transform.rotation;

        // Start the timer
        timeActivated = Time.time;
    }

    void Update()
    {
        // Slowly reduce the objects alpha value by the alpha multiplier
        alpha *= alphaMultiplier;

        // Set the colours new alpha
        color = new Color(1f, 1f, 1f, alpha);

        // Set the sprite renderer colour
        sR.color = color;

        // Check if the object alive time is greater than the object active time
        if (Time.time > (timeActivated + activeTime))
        {
            // Add object back into the object pool
            ObjectPool.Instance.AddToPool(gameObject);
        }
    }
    #endregion

    #region User Methods

    #endregion
}