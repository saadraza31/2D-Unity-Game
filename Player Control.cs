using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool isGameOver = false;

    public GameObject gameOverText;
    public GameObject restartButton;

    private TextMeshProUGUI gameOverTMP;
    public ItemSpawner itemSpawner; // Reference to the ItemSpawner script

    // Add a score variable
    private int score = 0;
    public TextMeshProUGUI scoreText; // Reference to the score text UI

    // Add target score variable
    public int targetScore = 10; // Change this value as needed
    public TextMeshProUGUI targetValueText; // Target value text UI

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        gameOverTMP = gameOverText.GetComponent<TextMeshProUGUI>();
        gameOverTMP.alpha = 0;
        restartButton.SetActive(false);

        UpdateScoreUI();
        targetValueText.text = "Target: " + targetScore.ToString(); // Show target score
    }

    void Update()
    {
        if (isGameOver) return;

        if (Input.GetKey(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, 5f);
        }

        // Check if score has reached the target value and trigger the next level
        if (score >= targetScore)
        {
            NextLevel();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGameOver = true;
            StartCoroutine(FadeInGameOverText());
            restartButton.SetActive(true);
            gameOverText.SetActive(true);

            // Stop the item spawner
            if (itemSpawner != null)
            {
                itemSpawner.StopSpawning();
            }

            // Hide all existing trash items
            HideAllTrashItems();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isGameOver) return;

        if (collision.gameObject.CompareTag("Trash"))
        {
            Destroy(collision.gameObject); // Destroy the trash item
            IncreaseScore(); // Increase the score
        }
    }

    void IncreaseScore()
    {
        score += 1; // Increase score by 1
        UpdateScoreUI(); // Update score UI
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Score: " + score.ToString(); // Update score text
    }

    IEnumerator FadeInGameOverText()
    {
        float alpha = 0;
        while (alpha < 1)
        {
            alpha += Time.deltaTime;
            gameOverTMP.alpha = alpha;
            yield return null;
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    // New method for transitioning to the next level
    void NextLevel()
    {
        // Load the next scene (change the build index if needed)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Hide all existing trash items when the game is over
    void HideAllTrashItems()
    {
        GameObject[] trashItems = GameObject.FindGameObjectsWithTag("Trash");

        foreach (GameObject trash in trashItems)
        {
            trash.SetActive(false); // Deactivate the trash items
        }
    }
}

