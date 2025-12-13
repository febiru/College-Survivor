using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ExperienceManager : MonoBehaviour
{
    [SerializeField] AnimationCurve experienceCurve;

    int currentLevel, totalExperience;
    int previousLevelExperience, nextLevelExperience;

    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] Image experienceFill;

    void Start()
    {
        UpdateLevel();
    }

    void Update()
    {
        
    }

    public void AddExperience(int amount)
    {
        totalExperience += amount;
        CheckForLevelUp();
        UpdateInterface();
    }

    void CheckForLevelUp()
    {
        // handle multiple level-ups if a large amount of XP is added at once
        while (totalExperience >= nextLevelExperience)
        {
            currentLevel++;
            UpdateLevel();
        }
    }

    void UpdateLevel()
    {
        // Evaluate needs a valid input — use previous level and current level
        previousLevelExperience = (int)experienceCurve.Evaluate(Mathf.Max(0, currentLevel - 1));
        nextLevelExperience = (int)experienceCurve.Evaluate(currentLevel);
        UpdateInterface();
    }

    void UpdateInterface()
    {
        int start = totalExperience - previousLevelExperience;
        int end = Mathf.Max(1, nextLevelExperience - previousLevelExperience); // avoid divide by zero

        levelText.text = currentLevel.ToString();
        experienceFill.fillAmount = (float)start / (float)end;
    }
}
