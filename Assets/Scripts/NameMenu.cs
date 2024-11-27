using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class NameMenu : MonoBehaviour
{
    [SerializeField] private TMP_InputField nameInput;
    [SerializeField] GameObject nextButton;
    [SerializeField] private TMP_Text inputLabel;
    public void SaveName()
    {
        PlayerPrefs.SetString("PlayerName", nameInput.text);
    }
    
    public void Next()
    {
        if (string.IsNullOrEmpty(nameInput.text))
        {
            inputLabel.color = Color.red;
        }
        else
        {
            SaveName();
            SceneManager.LoadScene("Main Menu");
        }
    }
    void Start()
    {
        PlayerPrefs.DeleteAll();
    }
}
