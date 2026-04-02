using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Jump Settings")]
    public float jumpForce = 5f;
    public float groundDistance = 0.3f;
    public LayerMask groundLayer;

    [Header("Lane Settings")]
    private int currentLane = 0; // 
    private float laneDistance = 2f;

    private bool grounded;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
    }

    public void MoveRight(InputAction.CallbackContext context)
{
    if (!context.performed) return;

    if (currentLane < 1)
    {
        currentLane++;
        UpdatePosition();
    }
}

public void MoveLeft(InputAction.CallbackContext context)
{
    if (!context.performed) return;

    if (currentLane > -1)
    {
        currentLane--;
        UpdatePosition();
    }
}

    void UpdatePosition()
    {
        Vector3 newPos = new Vector3(
            rb.position.x,
            rb.position.y,
            currentLane * laneDistance 
        );

        rb.position = newPos;
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}