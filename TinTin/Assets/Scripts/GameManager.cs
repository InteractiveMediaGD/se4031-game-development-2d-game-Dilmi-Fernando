using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private bool isGameOver = false;

    void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        if (isGameOver) return;
        isGameOver = true;
        Time.timeScale = 0f;
        UIManager.Instance.ShowGameOver(
            ScoreManager.Instance.GetScore(),
            ScoreManager.Instance.GetHighScore()
        );
    }

    public void RestartGame()
    {
        isGameOver = false;
        Time.timeScale = 1f;
        ScoreManager.Instance.ResetScore();
        HealthManager.Instance.ResetHealth();
        GameSpeedManager.Instance.ResetSpeed();
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
        );
    }
}
