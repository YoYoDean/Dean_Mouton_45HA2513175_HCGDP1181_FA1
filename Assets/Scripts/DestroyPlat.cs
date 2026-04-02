using UnityEngine;

public class DestroyPlat : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            Debug.Log("Detroy");
            Destroy(other.gameObject); 
        } 
    }
}
