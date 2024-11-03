using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Player movement speed
    public float runSpeedMultiplier = 2f; // Speed multiplier for running
    public float jumpForce = 5f; // Jump force
    private Rigidbody rb; // Reference to the Rigidbody component
    private Renderer playerRenderer; // Reference to the player's Renderer
    private bool isGrounded; // Is the player on the ground?

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        playerRenderer = GetComponent<Renderer>(); // Get the Renderer component
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor in the center of the screen
    }

    void Update()
    {
        // Get input for player movement
        float moveHorizontal = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveVertical = Input.GetAxis("Vertical");     // W/S or Up/Down

        // Calculate movement direction based on camera rotation
        Vector3 forward = Camera.main.transform.TransformDirection(Vector3.forward); // Camera forward direction
        Vector3 right = Camera.main.transform.TransformDirection(Vector3.right); // Camera right direction

        // Calculate movement vector based on input
        Vector3 movement = (forward * moveVertical + right * moveHorizontal).normalized;

        // Determine the current speed
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift)) // Check if running
        {
            currentSpeed *= runSpeedMultiplier; // Increase speed when running
        }

        // Move the player
        Vector3 moveDirection = movement * currentSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + moveDirection);

        // Jumping logic
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        // Change color logic
        if (Input.GetKeyDown(KeyCode.C))
        {
            ChangeColor(); // Change player color
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse); // Apply jump force
        isGrounded = false; // Set isGrounded to false after jumping
    }

    private void ChangeColor()
    {
        // Generate a random color
        Color randomColor = new Color(Random.value, Random.value, Random.value);
        playerRenderer.material.color = randomColor; // Change the player's material color
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player touches the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Set isGrounded to true
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player leaves the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Set isGrounded to false
        }
    }
}
