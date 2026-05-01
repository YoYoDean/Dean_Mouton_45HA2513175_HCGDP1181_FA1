using System.Runtime.ConstrainedExecution;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class NewMove : MonoBehaviour
{
    public float speed = 5;
    public float jumpForce = 2;
    public float layer = 0.1f;
    public bool isGrounded;
    public Transform feet;
    public LayerMask groundMask;
    private Vector2 move;
    private Rigidbody rb ;
    private float moveInput;
    private bool jumpPress;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
        moveInput = move.x;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumpPress = context.ReadValueAsButton();
    }

    void FixedUpdate()
    {
        if (Physics.Raycast(feet.position, Vector3.down, layer, groundMask))
        { 
            isGrounded = true;  
        }
        else
        {
            isGrounded = false;
        }
        
        if(jumpPress && isGrounded) rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        Debug.Log(isGrounded);
        Vector3 moveTo = moveInput * speed * transform.forward;
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, rb.linearVelocity.y, moveTo.z);
    }

}
