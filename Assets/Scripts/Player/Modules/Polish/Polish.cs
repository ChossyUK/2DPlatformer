using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Polish : MonoBehaviour
{
    #region Variables
    [Header("Particles")]
    // Jump dust particle
    [SerializeField] ParticleSystem jumpParticle;

    // Wall slide particle to play when wall sliding
    [SerializeField] ParticleSystem wallSlideParticle;

    // Reference to the collisions script
    Collisions coll;
    // Reference to the collisions script animation state machine
    AnimationStateMachine stateMachine;
    // Bool for jump particle
    bool jumpFinished;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the collisions component
        coll = GetComponent<Collisions>();
        // Get the animation state machine
        stateMachine = GetComponent<AnimationStateMachine>();
        // Set the bool to true to stop the jump dust particle playing
        jumpFinished = true;
    }

    void Update()
    {
        // Check for landing a jump
        CheckGround();

        // Check if we are wall sliding
        if (stateMachine.state == AnimationStateMachine.AnimationStates.WallSliding)
        {
            // Play the wall slide particle
            wallSlideParticle.Play();
        }
    }
    #endregion

    #region User Methods
    void CheckGround()
    {
        // If we have jumped and touch the ground play the jump dust particle
        if (coll.IsGrounded && !jumpFinished)
        {
            // Play the jump dust particle
            jumpParticle.Play();
            // Set the bool to true
            jumpFinished = true;
        }

        // Set the bool to false to enable the jump dust particle to play
        if (!coll.IsGrounded && jumpFinished)
        {
            // Set the bool to false
            jumpFinished = false;
        }
    }
    #endregion
}