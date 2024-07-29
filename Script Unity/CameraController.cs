using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;  // GameObject to follow
    public float rotationSpeed = 5f;

    private Vector3 offset;

    void Start()
    {
        if (target != null)
            offset = transform.position - target.position;
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Rotate the camera by pressing the mouse scroll wheel
        if (Input.GetMouseButton(2))
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;

            target.Rotate(Vector3.up, mouseX, Space.World);
        }

        // Keep the Y altitude fixed
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.y = transform.position.y;

        // Update the camera position based on the target position
        transform.position = desiredPosition;
    }
}