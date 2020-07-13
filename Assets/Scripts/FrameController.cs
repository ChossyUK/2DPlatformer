using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CedarWoodSoftware
{
	public class FrameController : MonoBehaviour
	{
        #region Variables
        // Current frame
        [Header("Current Active Frame")]
        [SerializeField] GameObject activeFrame = null;

        // Array of remaing frames
        [Header("Inactive Frames")]
        [SerializeField] GameObject[] otherFrames;
        #endregion

        #region Unity Base Methods
        void OnTriggerEnter2D(Collider2D collision)
        {
            // Check what frame we are in and activate it & deactivate the other frames in the array
            if (collision.tag == "Player")
            {
                // Activate the current frame
                activeFrame.SetActive(true);

                // Loop through and deactivate all the other frames in the array
                for (int i = 0; i < otherFrames.Length; i++)
                {
                    otherFrames[i].SetActive(false);
                }
            }
        }
        #endregion
    }
}