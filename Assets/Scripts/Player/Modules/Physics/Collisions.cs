using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CedarWoodSoftware
{
	public class Collisions : MonoBehaviour
	{
        #region Variables
        // Private fields
        [Header("Collision Checks")]
        // Ground checker radius
        [SerializeField] float groundCheckerRadius;
        // Wall checker radius
        [SerializeField] float wallCheckerLength;
        // Ledge checker radius
        [SerializeField] float ledgeCheckerLength;
        // Ground checker
        [SerializeField] Transform groundChecker;
        // Wall checker
        [SerializeField] Transform wallChecker;
        // Ledge checker
        [SerializeField] Transform ledgeChecker;
        // Ground layer
        [SerializeField] LayerMask groundLayer;
        // Wall layer
        [SerializeField] LayerMask wallLayer;

        // Public fields
        public Transform WallChecker
        {
            get { return wallChecker; }
        }

        public float WallCheckerLength
        {
            get { return wallCheckerLength; }
        }

        public bool IsGrounded
        {
            get { return isGrounded; }
            set { }
        }

        public bool IsTouchingWall
        {
            get { return isTouchingWall; }
        }

        public Transform LedgeChecker
        {
            get { return ledgeChecker; }
        }

        public float LedgeCheckerLength
        {
            get { return ledgeCheckerLength; }
        }

        public bool IsTouchingLedge
        {
            get { return isTouchingLedge; }
        }

        // Bools for physics
        bool isGrounded;
        bool isTouchingWall;
        bool isTouchingLedge;
        #endregion

        #region Unity Base Methods
        void FixedUpdate()
        {
            // Check the physics status
            CheckPhysics();
        }

        void OnDrawGizmos()
        {
            // Draw gizmos to see the settings
            Gizmos.DrawSphere(groundChecker.position, groundCheckerRadius);
            Gizmos.DrawLine(wallChecker.position, new Vector3(wallChecker.position.x + wallCheckerLength, wallChecker.position.y, wallChecker.position.z));
            Gizmos.DrawLine(ledgeChecker.position, new Vector3(ledgeChecker.position.x + ledgeCheckerLength, ledgeChecker.position.y, ledgeChecker.position.z));
        }
        #endregion

        #region User Methods
        void CheckPhysics()
        {
            // Check if the player is touching the ground
            isGrounded = Physics2D.OverlapCircle(groundChecker.position, groundCheckerRadius, groundLayer);

            // Check if the player is touching a wall
            isTouchingWall = Physics2D.Raycast(wallChecker.position, transform.right, wallCheckerLength, wallLayer);

            // Check if the player is touching a wall for ledge grab
            isTouchingLedge = Physics2D.Raycast(ledgeChecker.position, transform.right, ledgeCheckerLength, wallLayer);
        }
        #endregion
    }
}