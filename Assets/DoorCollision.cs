using UnityEngine;

public class DoorCollision : MonoBehaviour
{
    public Transform door;  // Reference to the door object (set in the inspector)
    public Vector3 openPosition;  // The position where the door will be when open
    public Vector3 closedPosition;  // The position where the door will be when closed
    public Vector3 openRotation;  // The rotation where the door will be when open (Euler Angles)
    public Vector3 closedRotation;  // The rotation where the door will be when closed (Euler Angles)

    private bool isNearPlayer = false;  // Flag to check if the player is near the door

    void Start()
    {
        // Ensure the door starts in the closed position and rotation when the game begins
        door.position = closedPosition;
        door.rotation = Quaternion.Euler(closedRotation);
    }

    void Update()
    {
        // Only update the door when proximity changes (no continuous movement)
        if (isNearPlayer)
        {
            // If the player is near, set the door to the open position and rotation
            door.position = closedPosition;
            door.rotation = Quaternion.Euler(closedRotation);
        }
        else
        {
            // If the player is not near, set the door to the closed position and rotation
           

            door.position = openPosition;
            door.rotation = Quaternion.Euler(openRotation);
        }
    }

    // Called when the player enters the trigger area
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure that the player has entered the trigger
        {
            // When the player enters proximity, open the door
            isNearPlayer = true;
        }
    }

    // Called when the player exits the trigger area
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))  // Ensure the player has exited the trigger
        {
            // When the player exits proximity, close the door
            isNearPlayer = false;
        }
    }
}
