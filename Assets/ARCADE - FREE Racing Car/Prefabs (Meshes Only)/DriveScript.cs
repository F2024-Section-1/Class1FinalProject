using UnityEngine;

public class DriveScript : MonoBehaviour
{
    public float speed = 10f;           // Forward/backward speed
    public float turnSpeed = 100f;      // Turning speed
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Get input for moving forward and backward (W/S or Up/Down Arrow keys)
        float moveInput = Input.GetAxis("Vertical");

        // Get input for turning (A/D or Left/Right Arrow keys)
        float turnInput = Input.GetAxis("Horizontal");

        // Apply movement and turning
        MoveCar(moveInput);
        TurnCar(turnInput);
    }

    void MoveCar(float moveInput)
    {
        // Move the car based on input
        Vector3 moveDirection = transform.forward * moveInput * speed * Time.deltaTime;

        // Apply force to move the car using Rigidbody
        rb.AddForce(moveDirection, ForceMode.VelocityChange); // Use velocity change for direct control
    }

    void TurnCar(float turnInput)
    {
        // Turn the car based on input
        float turnAmount = turnInput * turnSpeed * Time.deltaTime;
        rb.AddTorque(Vector3.up * turnAmount, ForceMode.VelocityChange);  // Apply torque to rotate the car
    }
}
