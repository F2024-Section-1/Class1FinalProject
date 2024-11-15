using UnityEngine;

public class CarController : MonoBehaviour
{
    public WheelCollider[] wheels;
    public float speed = 10.0f;
    public float turnSpeed = 10.0f;

    void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        foreach (WheelCollider wheel in wheels)
        {
            wheel.motorTorque = moveInput * speed;
        }

        float turnInput = Input.GetAxis("Horizontal");
        foreach (WheelCollider wheel in wheels)
        {
            wheel.steerAngle = turnInput * turnSpeed;
        }
    }
}
