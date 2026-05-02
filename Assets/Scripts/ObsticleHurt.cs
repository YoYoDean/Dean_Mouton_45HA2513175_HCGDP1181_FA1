using UnityEngine;

public class ObsticleHurt : MonoBehaviour
{
    /*void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Ouch");
            Health.instance.HurtPlayer(10);           
        }
    }*/

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Ouch");
            Health.instance.HurtPlayer(10);           
        }
    }
}
