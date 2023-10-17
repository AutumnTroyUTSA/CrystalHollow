using UnityEngine;
using UnityEngine.UI;

public class CharacterDisplay : MonoBehaviour
{
    public Image characterImage; // Reference to the Image component for character display.
    public Text playerNameText; // Reference to the Text component for player name.

    private void Start()
    {
        // Load the selected character using PlayerPrefs.
        string selectedCharacter = PlayerPrefs.GetString("SelectedCharacter");

        // Load the player name using PlayerPrefs.
        string playerName = PlayerPrefs.GetString("PlayerName");

        // Display the character image based on the selected character.
        if (selectedCharacter == "Character1")
        {
            // Assign the sprite for Character1 to the characterImage.
        }
        else if (selectedCharacter == "Character2")
        {
            // Assign the sprite for Character2 to the characterImage.
        }

        // Display the player name.
        playerNameText.text = playerName;
    }
}