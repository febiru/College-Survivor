using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TMPro.TextMeshProUGUI pointsText;
    public GameObject deathAudio;
    public GameObject BackgroundMusic;

    // Existing method kept for compatibility
    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = "Final Score: " + score.ToString();
        deathAudio.SetActive(true);
        BackgroundMusic.SetActive(false);
    }

    // New convenience method: read score from HighScore singleton
    public void Setup()
    {
        int score = 0;
        if (HighScore.Instance != null)
            score = HighScore.Instance.CurrentScore;

        Setup(score);
    }

    public void RestartGame()
    {
        if (HighScore.Instance != null)
            HighScore.Instance.ResetSessionScore();

        SceneManager.LoadScene("College Survivor");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
