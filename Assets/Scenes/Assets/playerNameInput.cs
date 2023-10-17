using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerNameInput : MonoBehaviour
{
    public InputField nameInputField;

    private void Start()
    {
        // Load the saved player name, if available.
        string savedName = PlayerPrefs.GetString("PlayerName");
        if (!string.IsNullOrEmpty(savedName))
        {
            nameInputField.text = savedName;
        }
    }

    public void SavePlayerName()
    {
        string playerName = nameInputField.text;
        PlayerPrefs.SetString("PlayerName", playerName);
    }
}