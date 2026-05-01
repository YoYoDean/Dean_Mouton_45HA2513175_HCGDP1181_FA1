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
    private bool isPressed;
    public Transform player;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Ground check
        grounded = Physics.Raycast(transform.position, Vector3.down, groundDistance, groundLayer);
    }

    public void MoveRight(){
    //if (!context.performed) return;

    if (!isPressed)
    {
        Debug.Log(player.position);
        currentLane += 2 ;
        //Vector3 currPos = new Vector3(4.5f, 0.7f, currentLane);
        Vector3 newPos = new(0, 0, 2);
        Vector3 newposition = player.position + newPos;
        player.transform.position = newposition ;
    }
}

public void MoveLeft()
{
    //if (!context.performed) return;

    if (!isPressed)
    {
        Debug.Log(player.position);
        currentLane -= 2;
        //UpdatePosition();
        //Vector3 currPos = new Vector3(4.5f, 0.7f, currentLane);
        Vector3 newPos = new(0, 0, -2);
        Vector3 newposition = player.position + newPos;
        player.transform.position = newposition ;
    }
    
}

    void UpdatePosition()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, currentLane * laneDistance );

        gameObject.transform.Translate(newPos);
    }


    public void Jump(InputAction.CallbackContext context)
    {
        if (context.performed && grounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }
}