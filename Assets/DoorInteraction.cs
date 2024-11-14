using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public float openSpeed = 2f;        // Speed of door opening/closing
    public float openAngle = 90f;       // Angle the door will open (degrees)
    public bool isOpen = false;         // Current state of the door (open or closed)
    private Quaternion closedRotation;  // The door's closed rotation
    private Quaternion openRotation;    // The door's open rotation

    private bool playerInRange = false; // Flag to check if the player is in range to interact
    private string playerTag = "Player"; // Tag of the player

    void Start()
    {
        // Store the initial closed rotation and calculate the open rotation
        closedRotation = transform.rotation;
        openRotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, openAngle, 0f));
    }

    void Update()
    {
        // Check if the player is in range and presses the interaction key
        if (playerInRange && Input.GetKeyDown(KeyCode.E)) // "E" key to interact
        {
            ToggleDoor();
        }

        // Smoothly rotate the door open or closed
        if (isOpen)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, openRotation, openSpeed * Time.deltaTime);
        }
        else
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, closedRotation, openSpeed * Time.deltaTime);
        }
    }

    // Trigger area to detect when the player enters or exits the door's interaction zone
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = true; // Player is within interaction range
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = false; // Player is out of range
        }
    }

    // Toggle the door's state between open and closed
    void ToggleDoor()
    {
        isOpen = !isOpen; // Change the state of the door
    }
}
