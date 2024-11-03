using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;               // Reference to the player's transform
    public Vector3 offset;                 // Camera offset from the player
    public float smoothSpeed = 0.125f;     // Smooth follow speed
    public float mouseSensitivity = 100f;   // Sensitivity of mouse movement

    private float yaw;                     // Yaw rotation
    private float pitch;                   // Pitch rotation

    void Start()
    {
        // Set the camera's field of view
        Camera.main.fieldOfView = 60f; // Adjust this value as needed

        // Initialize yaw and pitch based on the current rotation
        yaw = transform.eulerAngles.y;
        pitch = transform.eulerAngles.x;
    }

    void LateUpdate()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Update yaw and pitch based on mouse input
        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -30f, 85f); // Clamp pitch to avoid flipping

        // Calculate the desired rotation
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // Calculate the desired position based on the player's position and the offset
        Vector3 desiredPosition = player.position + rotation * offset;

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;

        // Apply the rotation to the camera
        transform.rotation = rotation;
    }
}