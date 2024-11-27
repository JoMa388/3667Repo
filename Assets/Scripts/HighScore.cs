using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HighScore : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoreTexts;
    [SerializeField] GameObject scoreMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject Difficulty;
    void Start()
    {
        LoadScores();
    }
    private void LoadScores()
    {
        // Gets the top 5 times stored in PlayerPref, returns 0.0 if DNE
        for (int i = 0; i < 5; i++) {
            if (PlayerPrefs.GetFloat($"ScoreValue_{i}") != float.MaxValue) {
                float time = PlayerPrefs.GetFloat($"ScoreValue_{i}");
                int minutes = Mathf.FloorToInt(time / 60);  // Calculate minutes
                int seconds = Mathf.FloorToInt(time % 60); // Calculate seconds
                int milliseconds = Mathf.FloorToInt((time % 1) * 100);
                if (milliseconds == 100)
                {
                    milliseconds = 0;
                    seconds += 1; // Increment seconds if milliseconds overflow
                }
                string formattedTime = $"{minutes:D2}:{seconds:D2}:{milliseconds:D2}";
                scoreTexts[i].text = formattedTime;
            }
        }
        
    }
    public void Return()
    {
        Difficulty.SetActive(false);
        settingsMenu.SetActive(true);
        scoreMenu.SetActive(false);
    }
    public void DifficultyMenu()
    {
        Difficulty.SetActive(true);
        scoreMenu.SetActive(false);
    }
}
