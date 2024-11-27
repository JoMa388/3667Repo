using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject tutorialMenu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(2);    
    }
    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);   
    }
    public void Tutorial()
    {
        mainMenu.SetActive(false);
        tutorialMenu.SetActive(true);
    }
    
}
