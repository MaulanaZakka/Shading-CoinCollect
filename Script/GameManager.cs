using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // Singleton instance
    private int score = 0; // Player's score
    public GameObject coinPrefab; // Prefab for the coin
    public Transform[] spawnPoints; // Array of spawn points
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component for displaying score

    private void Awake()
    {
        // Ensure only one instance of GameManager exists
        if (instance == null)
        {
            instance = this;
            // Optional: Keep the GameManager across scenes
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate GameManager
        }
    }

    private void Start()
    {
        SpawnNewCoin(); // Spawn the first coin
        UpdateScoreUI(); // Initialize the score display
    }

    public void AddScore(int value)
    {
        score += value; // Add points to score
        UpdateScoreUI(); // Update the UI whenever score changes
        Debug.Log("Score: " + score); // Log the score to the console
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString(); // Update the score text
        }
        else
        {
            Debug.LogWarning("ScoreText is not assigned in the inspector!"); // Warning if scoreText is not assigned
        }
    }

    public void SpawnNewCoin()
    {
        if (spawnPoints.Length > 0)
        {
            int randomIndex = Random.Range(0, spawnPoints.Length); // Get a random spawn point index
            Instantiate(coinPrefab, spawnPoints[randomIndex].position, Quaternion.identity); // Spawn a new coin
        }
        else
        {
            Debug.LogWarning("No spawn points assigned!"); // Warning if no spawn points are available
        }
    }
}