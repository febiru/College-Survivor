using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScore : MonoBehaviour
{
    public static HighScore Instance { get; private set; }

    [Header("Optional UI")]
    [SerializeField] private TextMeshProUGUI currentScoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;

    private const string HighScoreKey = "HighScore";
    public int CurrentScore { get; private set; }
    public int HighScoreValue { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadHighScore();
        UpdateUI();
    }

    private void LoadHighScore()
    {
        HighScoreValue = PlayerPrefs.GetInt(HighScoreKey, 0);
    }

    private void SaveHighScore()
    {
        PlayerPrefs.SetInt(HighScoreKey, HighScoreValue);
        PlayerPrefs.Save();
    }

    public void AddScore(int amount)
    {
        if (amount <= 0) return;
        CurrentScore += amount;

        if (CurrentScore > HighScoreValue)
        {
            HighScoreValue = CurrentScore;
            SaveHighScore();
        }

        UpdateUI();
    }

    public void ResetSessionScore()
    {
        CurrentScore = 0;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if (currentScoreText) currentScoreText.text = CurrentScore.ToString();
        if (highScoreText) highScoreText.text = HighScoreValue.ToString();
    }
}
