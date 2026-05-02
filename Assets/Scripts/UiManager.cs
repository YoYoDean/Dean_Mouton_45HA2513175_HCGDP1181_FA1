using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScoreMain;
    public TextMeshProUGUI highScoreGameOver;
    public float iScore;
    public static UiManager instance;



    void Awake()
{
    if (instance != null && instance != this)
    {
        Destroy(gameObject);
        return;
    }

    instance = this;
}
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "FA2")
        {
            iScore += Time.deltaTime;
            score.text = "Score: " + iScore;
        }
    }
    public void UpdateHealth(float healthIn)
    {
        health.text = "Health: " + healthIn;
    }
    public void UpdateScore()
        {
            if (highScoreGameOver != null) highScoreGameOver.text = "HighScore: " + PlayerPrefs.GetFloat("highScore");
            if (highScoreMain != null) highScoreMain.text = "HighScore: " + PlayerPrefs.GetFloat("highScore");
        }

}

