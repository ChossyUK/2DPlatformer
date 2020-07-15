using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationStateMachine : MonoBehaviour
{
    #region Variables
    // Animation states
    public enum AnimationStates { Idle, Walking, ClimbingLadder, ClimbingWall, Jumping, Dashing, WallGrabbing, WallJumping, WallSliding, LedgeGrabbing }

    // Set the default state
    public AnimationStates state = AnimationStates.Idle;

    // References to the controller scripts
    Animator animator;
    PlayerController playerController;
    WallClimb wallClimb;
    WallSlide wallSlide;
    //WallJump wallJump;
    Dash dash;
    //LedgeGrab ledgeGrab;
    #endregion

    #region Unity Base Methods
    void Start()
    {
        // Get the components
        animator = GetComponentInChildren<Animator>();
        playerController = GetComponent<PlayerController>();
        wallSlide = GetComponent<WallSlide>();
        wallClimb = GetComponent<WallClimb>();
        //wallJump = GetComponent<WallJump>();
        //ledgeGrab = GetComponent<LedgeGrab>();
        dash = GetComponent<Dash>();
    }

    void Update()
    {
        // Check and swap the current state
        SwapStates();

        // Play the current state animation
        PlayStates();
    }
    #endregion

    #region User Methods
    void SwapStates()
    {
        // Set state to idle or walking depending on player input
        if (playerController.X < -0.2f || playerController.X > 0.2f)
        {
            state = AnimationStates.Walking;
        }
        else
        {
            state = AnimationStates.Idle;
        }

        // Set state to jumping
        if (playerController.IsJumping)
        {
            state = AnimationStates.Jumping;
        }

        // Set state to wall grabbing
        if (wallClimb.IsWallGrabbing)
        {
            state = AnimationStates.WallGrabbing;
        }

        // Set state to wall climbing
        if (wallClimb.IsWallClimbing)
        {
            state = AnimationStates.ClimbingWall;
        }

        // Set state to wall sliding
        if (wallSlide.IsWallSliding)
        {
            state = AnimationStates.WallSliding;
        }

        //// Set state to wall jumping
        //if (wallJump.WallJumped)
        //{
        //    state = AnimationStates.WallJumping;
        //}

        //// Set state to ledge grabbing
        //if (ledgeGrab.CanGrabLedge)
        //{
        //    state = AnimationStates.LedgeGrabbing;
        //}
    }

    void PlayStates()
    {
        switch (state)
        {
            case AnimationStates.Idle:
                PlayAnimation("Idle");
                break;
            case AnimationStates.Walking:
                PlayAnimation("Walk");
                break;
            case AnimationStates.ClimbingLadder:
                PlayAnimation("");
                break;
            case AnimationStates.ClimbingWall:
                PlayAnimation("WallClimb");
                break;
            case AnimationStates.Jumping:
                PlayAnimation("Jump");
                break;
            case AnimationStates.Dashing:
                PlayAnimation("");
                break;
            case AnimationStates.WallGrabbing:
                PlayAnimation("WallGrab");
                break;
            case AnimationStates.WallSliding:
                PlayAnimation("WallSlide");
                break;
            case AnimationStates.WallJumping:
                PlayAnimation("Jump");
                break;
            case AnimationStates.LedgeGrabbing:
                PlayAnimation("LedgeGrab");
                break;
            default:
                break;
        }
    }

    void PlayAnimation(string animationName)
    {
        // Play the current state animation
        animator.Play(animationName);
    }
    #endregion
}