using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public Transform xrOrigin;             // Reference to the XR Origin (VR headset or player object)
    public float detectionRange = 2f;      // Distance at which the door opens
    public Vector3 openRotation;           // Rotation angle when the door is open
    public Vector3 closedRotation;         // Rotation angle when the door is closed
    public float openSpeed = 2f;           // Speed at which the door opens/closes

    private bool isOpen = false;
    private Quaternion targetRotation;

    private void Start()
    {
        // Set the initial target rotation to closed position
        targetRotation = Quaternion.Euler(closedRotation);
    }

    private void Update()
    {
        // Check the distance between the XR Origin and the door
        float distance = Vector3.Distance(xrOrigin.position, transform.position);

        if (distance <= detectionRange && !isOpen)
        {
            OpenDoor();
        }
        else if (distance > detectionRange && isOpen)
        {
            CloseDoor();
        }

        // Smoothly rotate the door towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * openSpeed);
    }

    private void OpenDoor()
    {
        isOpen = true;
        targetRotation = Quaternion.Euler(openRotation);
    }

    private void CloseDoor()
    {
        isOpen = false;
        targetRotation = Quaternion.Euler(closedRotation);
    }
}
