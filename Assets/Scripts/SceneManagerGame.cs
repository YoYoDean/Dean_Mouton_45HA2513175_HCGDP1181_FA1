using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("FA2");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("Start");
    }
   
}
