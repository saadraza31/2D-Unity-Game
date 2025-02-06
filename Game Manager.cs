using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameOver { get; private set; } = false;

    public void GameOver()
    {
        IsGameOver = true;
        Debug.Log("Game Over! All activities stopped.");
    }

    public void RestartGame() // Optional for restarting logic
    {
        IsGameOver = false;
        Debug.Log("Game Restarted!");
    }
}
