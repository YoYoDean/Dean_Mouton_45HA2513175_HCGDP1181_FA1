using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private bool grounded = false;
    public float jumpSpeed = 5f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void MoveRight()
    {
        Vector3 right = new Vector3(0,0,1);
        if(!(rb.transform.position.z == 2))
        {
            rb.Move(rb.transform.position + right , Quaternion.identity);
        }
    }

    public void MoveLeft()
    {
        Vector3 left = new Vector3(0,0,-1);
        if(!(rb.transform.position.z == -2))
        {
            rb.Move(rb.transform.position + left, Quaternion.identity);
        }
    }

    public void Jump()
    {
            if (grounded)
            {
                rb.AddForce(Vector3.up * jumpSpeed);
            }
    }

}

