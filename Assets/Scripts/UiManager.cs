using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public TextMeshProUGUI health;
    public TextMeshProUGUI score;
    public float iScore;
    public static UiManager instance;



    void Awake()
    {
        instance = this;
        UpdateHealth();
    }
    void Update()
    {
        iScore += Time.deltaTime;
         score.text = "Score" + iScore;
    }
    public void UpdateHealth()
    {
        health.text = "Health: " + Health.instance.playerHealth;
    }
    
}
