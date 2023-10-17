using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public string selectedCharacter;
    public string playerName;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}