using UnityEngine;

public class ObsticleKill : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("You Died!");
            Time.timeScale = 0;
            Destroy(other.gameObject);
        }
    }
}
