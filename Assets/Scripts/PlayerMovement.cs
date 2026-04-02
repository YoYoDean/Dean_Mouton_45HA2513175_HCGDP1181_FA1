using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public bool grounded = false;
    public float jumpSpeed = 5f;
    public float groundDistance = 0.2f;
    public LayerMask groundLayer;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
        //Debug.DrawRay(transform.position, Vector3.down*10, Color.red);
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

    public void Jump(InputAction.CallbackContext context)
    {
            if (context.performed)
            {
                if(grounded)
                {
                Debug.Log("Jump");
                rb.AddForce(Vector3.up * jumpSpeed);
                }
            }
    }

}

