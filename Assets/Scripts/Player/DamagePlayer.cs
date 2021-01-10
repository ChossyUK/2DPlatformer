using UnityEngine;

namespace CedarWoodSoftware
{
	public class DamagePlayer : MonoBehaviour
	{
        #region Variables

        #endregion

        #region Unity Base Methods
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.tag == "Player")
            {
                collision.gameObject.GetComponent<Knockback>().DoKnockBack();

                // Damage the player
            }
        }
        #endregion

        #region User Methods

        #endregion
    }
}