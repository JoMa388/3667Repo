using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class TimeScript : MonoBehaviour
{
    private float gameTime;
    private bool isRunning;
    public Text timerText;
    void Start()
    {
        // Start Timer
        gameTime = 0f;
        isRunning = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            gameTime += Time.deltaTime; // Increment the timer
            UpdateTimerDisplay();
        }
    }
    private void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the current scene is the main menu
        if (scene.name == "Main Menu") // Replace "MainMenu" with the name of your main menu scene
        {
            Destroy(gameObject);
        }
    }
    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 2)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
   

    public void ToggleTimer()
    {
        if (isRunning == false)
        {
            isRunning = true;
        }
        else
        {
            isRunning = false; ;
        }
    }
    public void ResetTimer() { gameTime = 0f; }
    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(gameTime / 60F);
            int seconds = Mathf.FloorToInt(gameTime % 60F);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
    }

    public void AppendScore()
    {
        float Time = gameTime;
        float[] scores = new float[5]; // Array to store top 5 times

        // Gets the top 5 times stored in PlayerPrefs
        for (int i = 0; i < 5; i++)
        {
            scores[i] = PlayerPrefs.GetFloat($"ScoreValue_{i}", float.MaxValue); // Use float.MaxValue as placeholder for empty scores
        }

        // Check if the new score is the same as any of the existing ones before proceeding
        bool isDuplicate = false;
        for (int i = 0; i < 5; i++)
        {
            if (gameTime == scores[i]) // Check if the game time is the same as an existing score
            {
                isDuplicate = true;
                break; // Exit loop early if we find a duplicate
            }
        }

        // If the score is a duplicate, don't add it
        if (isDuplicate)
        {
            return; // Exit the method without making any changes
        }

        // Start at the bottom of best times and insert the new score if it's better
        bool added = false;
        for (int i = 4; i >= 0; i--)
        {
            if (gameTime < scores[i]) // Check if the new time is better than the current time in the top 5
            {
                // Shift the times down the list to make space for the new time
                if (i < 4) scores[i + 1] = scores[i]; // Shift the next better time
                scores[i] = gameTime; // Insert new time at the correct position
                added = true;
            }
            else
            {
                break; // No need to continue if the time is not better than the current one
            }
        }

        // Save the updated top 5 times back to PlayerPrefs
        if (added)
        {
            for (int i = 0; i < 5; i++)
            {
                PlayerPrefs.SetFloat($"ScoreValue_{i}", scores[i]);
            }
        }
    }
}
