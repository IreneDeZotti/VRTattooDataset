using UnityEngine;

public class CameraHeightController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float minHeight = 1f;
    public float maxHeight = 10f;

    void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate the new vertical position of the camera
        float newPositionY = transform.position.y + verticalInput * moveSpeed * Time.deltaTime;

        // Limit camera vertical position to the range minHeight - maxHeight
        newPositionY = Mathf.Clamp(newPositionY, minHeight, maxHeight);

        // Create a new vector fot the position with updated height 
        Vector3 newPosition = new Vector3(transform.position.x, newPositionY, transform.position.z);

        // Update camera position
        transform.position = newPosition;
    }
}