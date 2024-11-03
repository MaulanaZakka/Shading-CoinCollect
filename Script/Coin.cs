using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool isCollected = false; // Flag to ensure the coin is only collected once

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isCollected)
        {
            isCollected = true; // Mark the coin as collected
            GameManager.instance.AddScore(1); // Assuming there's a GameManager handling the score
            Destroy(gameObject); // Destroy the coin
            GameManager.instance.SpawnNewCoin(); // Spawn a new coin
        }
    }
}
