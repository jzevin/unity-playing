
using UnityEngine;


public class ProxZone : MonoBehaviour
{
    [SerializeField] private PlayerC player;
    [SerializeField] private Transform indicator;
    // detect if the player is in the proximity zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            // Debug.Log("Player is in the proximity zone");
            indicator.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player.gameObject)
        {
            // Debug.Log("Player is out of the proximity zone");
            indicator.gameObject.SetActive(false);
        }
    }
}
