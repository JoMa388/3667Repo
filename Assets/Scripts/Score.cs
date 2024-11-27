using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    [SerializeField] Text playerName;
    public int playerScore;
    public Text score;
    public TimeScript gameTime;
    public int requiredScore;
    private void Start()
    {
        gameTime = GameObject.FindGameObjectWithTag("Timer").GetComponent<TimeScript>();
        LoadPlayerName();
    }
    public void NextLevel()
    {   
        if(SceneManager.GetActiveScene().buildIndex == 4)
        {
            gameTime.AppendScore();
            SceneManager.LoadSceneAsync(1);
        }
        else { SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1); }
       
    }
    public void IncrementScore()
    {
        playerScore++;
        score.text =playerScore.ToString();
        if(playerScore == requiredScore)
        {
            NextLevel();
        }
    }
    public void DecrementScore()
    {
        if (playerScore > 0)
        {
            playerScore--;
            score.text = playerScore.ToString();
        }
    }
    public void Reset()
    {
        playerScore = 0;
        score.text = playerScore.ToString();
    }
    private void LoadPlayerName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            playerName.text = PlayerPrefs.GetString("PlayerName");
        }
        else
        {
            playerName.text = "Player1";
        }
    }
}
