using UnityEngine;

public class WaterBottle : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.hydration += 20;
            UiManager.instance.UpdateHydration(GameManager.instance.hydration);
            Destroy(this.gameObject);
        }
        //ill later add press e to pickup water
    }
}
