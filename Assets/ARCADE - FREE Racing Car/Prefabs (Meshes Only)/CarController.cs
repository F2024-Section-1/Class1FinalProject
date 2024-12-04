using UnityEngine;

public class CarController : MonoBehaviour
{
    public float speed = 10f;           // Forward/backward speed
    public float turnSpeed = 50f;      // Turning speed
    public float maxSpeed = 20f;       // Maximum speed

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Get input from the keyboard
        float moveInput = Input.GetAxis("Vertical");   // W/S or Up/Down keys
        float turnInput = Input.GetAxis("Horizontal"); // A/D or Left/Right keys

        // Calculate movement
        Vector3 moveDirection = transform.forward * moveInput * speed;

        // Apply movement
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.AddForce(moveDirection, ForceMode.Acceleration);
        }

        // Apply turning
        float turn = turnInput * turnSpeed * Time.deltaTime;
        transform.Rotate(0, turn, 0);
    }
}
