using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class clickSound : MonoBehaviour
{
    public Button switchButton; // Assign your button in the Inspector.
    public AudioSource buttonClickSound; // Assign the AudioSource component in the Inspector.

    private void Start()
    {
        // Add a listener to the button's click event.
        switchButton.onClick.AddListener(PlaySoundOnClick);
    }

    private void PlaySoundOnClick()
    {
        // Play the button click sound.
        buttonClickSound.Play();

    }

}