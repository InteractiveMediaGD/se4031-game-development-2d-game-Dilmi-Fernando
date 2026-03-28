using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    private int score = 0;
    private int highScore = 0;

    void Awake()
    {
        Instance = this;
        // Load saved high score
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        score += amount;

        // Update high score if beaten
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }

        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (UIManager.Instance != null)
            UIManager.Instance.UpdateScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    public int GetScore()
    {
        return score;
    }

    public int GetHighScore()
    {
        return highScore;
    }
}