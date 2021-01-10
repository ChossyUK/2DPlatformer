using UnityEngine;

namespace CedarWoodSoftware
{
	public class FallDamage : MonoBehaviour
	{
        #region Variables
        [SerializeField] float maxFallHeight = 10f;
        [SerializeField] float damageAmt = 10f;

        bool isFalling = false;
        float maxHeight;

        // Reference to the components
        AnimationStateMachine animationStateMachine;
        PlayerController playerController;
        Collisions coll;
        WallClimb wallClimb;
        WallSlide wallSlide;
        #endregion

        #region Unity Base Methods
        void Start()
		{
            // Get the components
            animationStateMachine = GetComponent<AnimationStateMachine>();
            playerController = GetComponent<PlayerController>();
            coll = GetComponent<Collisions>();
            wallSlide = GetComponent<WallSlide>();
            wallClimb = GetComponent<WallClimb>();
        }

		void Update()
		{
            // Check for falling state
            if (animationStateMachine.state == AnimationStateMachine.AnimationStates.Falling)
            {
                // Check & set the fall height position
                if (!isFalling)
                {
                    isFalling = true;
                    maxHeight = playerController.transform.position.y;
                }
            }

            // Stop the damage if player wall grabs or slides
            if (wallClimb.IsWallGrabbing || wallSlide.IsWallSliding)
                isFalling = false;

            // Check when player hits the ground
            if (coll.IsGrounded && isFalling)
            {
                // Check if the player has fallen further than the max fall height
                if (maxHeight - playerController.transform.position.y >= maxFallHeight)
                {
                    // Damage the player
                    Debug.Log("Take Damage");
                }

                // Reset the fall damage
                maxHeight = 0;
                isFalling = false;
            }
        }
		#endregion

		#region User Methods
			
		#endregion
	}
}