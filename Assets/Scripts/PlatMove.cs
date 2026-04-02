using UnityEngine;

public class PlatMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()

    {
        MovePlat();
    }

    void MovePlat()
    {
        
        Vector3 movement = Vector3.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

}
