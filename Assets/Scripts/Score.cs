using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Score : MonoBehaviour
{
    public int playerScore;
    public Text score;
    public void NextLevel()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void IncrementScore()
    {
        playerScore++;
        score.text =playerScore.ToString();
        if(playerScore ==10)
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
}
