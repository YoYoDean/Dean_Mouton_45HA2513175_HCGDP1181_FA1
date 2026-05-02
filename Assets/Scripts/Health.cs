using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public float playerHealth = 100f;
    public float enemyHealth = 100f;
    private GameObject playerObj;
    public static Health instance;
    private UiManager uiManager;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        uiManager = GameObject.FindGameObjectWithTag("UiManager").GetComponent<UiManager>();

    }

    public void HealPlayer() // 
    {
        playerHealth += 30;
        UiManager.instance.UpdateHealth(playerHealth);
    }
    public void EnergyDrink()
    {
       //put speed
    }
    public void Alcohol()
    {
        playerHealth *= 2;
        UiManager.instance.UpdateHealth(playerHealth);
    }
    public void HurtPlayer(int hurtAmount)
    {
        playerHealth -= hurtAmount;
        UiManager.instance.UpdateHealth(playerHealth);
        if (playerHealth <= 0)
        {   
            GameManager.instance.UpdateHighScore();
            
            Debug.Log("Player Killed!");
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene("Game Over");
        }
    }
    /*public void HurtEnemy(int hurtAmount)
    {
        enemyHealth -= hurtAmount;
        if (enemyHealth <= 0)
        {
            Debug.Log("Enemy Killed!");
            //GameManager.instance.enemyKilled += 1;
            PlayerPrefs.SetInt("EnemiesKilled", PlayerPrefs.GetInt("EnemiesKilled") + 1);
            //uiManager.UpdateScore();
            Destroy(gameObject);
        }
    }*/

}
