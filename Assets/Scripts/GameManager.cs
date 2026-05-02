using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private float highScore;
    public static GameManager instance;


    void Awake()
    {
        instance = this;
    }
    void Start()
{
    
    if (PlayerPrefs.HasKey("highScore"))
    {
        highScore = PlayerPrefs.GetFloat("highScore");

        if (SceneManager.GetActiveScene().name == "Start")
        {
            UiManager.instance?.UpdateScore();
        }
        if (SceneManager.GetActiveScene().name == "Game Over")
        {
            UiManager.instance?.UpdateScore();
        }
    }
}


    public void UpdateHighScore()
    {
        if (UiManager.instance.iScore > PlayerPrefs.GetFloat("highScore"))
        {
            Debug.Log("New HighScore Saved");
            PlayerPrefs.SetFloat("highScore", UiManager.instance.iScore);
        }
    }

}
