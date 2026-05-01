using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTouch : MonoBehaviour
{
    public Transform player;
    public float zClamp = 3f;
    public float sensitivity = 0.1f;
    private bool jumpPress;
    private Rigidbody rb ;
    public float jumpForce = 2;
    public float layer = 0.1f;
    public bool isGrounded;
    public Transform feet;
    public LayerMask groundMask;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {   
        if (Mouse.current.leftButton.isPressed)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();

            Ray ray = Camera.main.ScreenPointToRay(mousePos);
            Plane plane = new(Vector3.up, Vector3.zero);

            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldPos = ray.GetPoint(distance);

                float targetZ = Mathf.Clamp(worldPos.z, -zClamp, zClamp); //clamp axis

                // sensitivity
                float newZ = Mathf.Lerp(player.position.z, targetZ, sensitivity);

                player.position = new Vector3(
                    player.position.x,   
                    player.position.y,
                    newZ
                );
            }
          }  
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
        //Debug.Log(isGrounded);
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        jumpPress = context.ReadValueAsButton();
    }
    }
