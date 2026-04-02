using UnityEngine;

public class PlatMove : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 2.5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + Vector3.right * speed * Time.fixedDeltaTime);
    }

    void MovePlat()
    {
        Vector3 movement = Vector3.right * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }
}