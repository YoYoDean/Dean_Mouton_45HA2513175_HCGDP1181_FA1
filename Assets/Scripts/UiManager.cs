using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScoreMain;
    public TextMeshProUGUI highScoreGameOver;
    public TextMeshProUGUI hydration;
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
            score.text = "Time: " + Math.Round(iScore , 2);
        }
    }
    public void UpdateHealth(float healthIn)
    {
        health.text = "Health: " + Math.Round(healthIn) + "/100";
    }
    public void UpdateScore()
        {
            if (highScoreGameOver != null) highScoreGameOver.text = "HighScore: " + Math.Round(PlayerPrefs.GetFloat("highScore")) + "  Seconds";
            if (highScoreMain != null) highScoreMain.text = "HighScore: " + Math.Round(PlayerPrefs.GetFloat("highScore")) + "  Seconds";
        }

    public void UpdateHydration(float hydrationInp)
    {
        hydration.text = "Hydration: " + Math.Round(hydrationInp) + "/100";
    }

}

