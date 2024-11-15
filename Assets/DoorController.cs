using System.Collections;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public Transform door; // The door's Transform
    public Transform xrCharacter; // The XR character's Transform
    public float detectionRange = 3f; // The range within which the door opens
    public float openSpeed = 2f; // Speed of door opening/closing
    public Vector3 openPosition; // The position when the door is open
    public Vector3 closedPosition; // The position when the door is closed

    private bool isOpen = false;

    void Start()
    {
        // Initialize door to the closed position
        door.localPosition = closedPosition;
    }

    void Update()
    {
        // Check the distance between the door and the XR character
        float distance = Vector3.Distance(xrCharacter.position, transform.position);

        if (distance <= detectionRange && !isOpen)
        {
            // Open the door if the character is within range
            StopAllCoroutines();
            StartCoroutine(MoveDoor(openPosition));
            isOpen = true;
        }
        else if (distance > detectionRange && isOpen)
        {
            // Close the door if the character moves out of range
            StopAllCoroutines();
            StartCoroutine(MoveDoor(closedPosition));
            isOpen = false;
        }
    }

    IEnumerator MoveDoor(Vector3 targetPosition)
    {
        // Smoothly move the door to the target position
        while (Vector3.Distance(door.localPosition, targetPosition) > 0.01f)
        {
            door.localPosition = Vector3.Lerp(door.localPosition, targetPosition, Time.deltaTime * openSpeed);
            yield return null;
        }
        // Snap the door to the final position to avoid float precision errors
        door.localPosition = targetPosition;
    }
}
