using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SettingMenu : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject tutorialMenu;
    [SerializeField] GameObject scoreMenu;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;
    [SerializeField] private TMP_Dropdown myDropdown;
    [SerializeField] private TMP_InputField nameInput;
    // Start is called before the first frame update
    void Start()
    {
        PlayerSettingChecker();
    }

    // Return Button
    public void Return()
    {
        SetVolume();
        SaveName();
        mainMenu.SetActive(true);
        settingsMenu.SetActive(false);
        tutorialMenu.SetActive(false);
        scoreMenu.SetActive(false);

    }

    // Dropdown Menu 
    public void SpriteMenu(int index)
    {
        switch (index)
        {
            case 0: PlayerPrefs.SetString("spriteColor", "1,1,1,1"); break;
            case 1: PlayerPrefs.SetString("spriteColor", "0,0,1,1"); break;
            case 2: PlayerPrefs.SetString("spriteColor", "1,1,0,1"); break;
        }
    }
    // Check for Player Settings 
    public void PlayerSettingChecker()
    {
        if (PlayerPrefs.HasKey("musicVolume") || PlayerPrefs.HasKey("SFXVolume"))
        {
            musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
            SFXSlider.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        if (PlayerPrefs.HasKey("spriteColor"))
        {
            if (PlayerPrefs.GetString("spriteColor") == "1,1,1,1")
            {
                myDropdown.value = 0;
            }
            if (PlayerPrefs.GetString("spriteColor") == "0,0,1,1")
            {
                myDropdown.value = 1;
            }
            if (PlayerPrefs.GetString("spriteColor") == "1,1,0,1")
            {
                myDropdown.value = 2;
            }
        }
        if(PlayerPrefs.HasKey("PlayerName"))
        {
            LoadName();
        }
    }


    public void LoadName()
    {
        if (PlayerPrefs.HasKey("PlayerName"))
        {
            nameInput.text = PlayerPrefs.GetString("PlayerName");
        }
    }

    private void SetVolume()
    {
        PlayerPrefs.SetFloat("musicVolume", musicSlider.value);
        PlayerPrefs.SetFloat("SFXVolume", SFXSlider.value);
    }

    public void SaveName()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
    }
    public void HighScores ()
    {
        SetVolume();
        SaveName();
        settingsMenu.SetActive(false);
        scoreMenu.SetActive(true);
    }
}
