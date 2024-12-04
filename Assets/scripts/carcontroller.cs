using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carcontroller : MonoBehaviour
{
    public WheelCollider frontrightwheelcollider;
    public WheelCollider backrightwheelcollider;
    public WheelCollider frontleftwheelcollider;
    public WheelCollider backleftwheelcollider;

    public Transform frontrightwheeltransform;
    public Transform backrightwheeltransform;
    public Transform frontleftwheeltransform;
    public Transform backleftwheeltransform;

    public Transform CarCentreOfMassTransform;
    public Rigidbody rigidbody; 
    public float motorForce= 100f;


    float verticalInput;
    float horizontalInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.centerOfMass=CarCentreOfMassTransform.localPosition;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Motorforce();
        UpdateWheels();
        GetInput();
        Steering();
        ApplyBrakes();


    }
    void GetInput()
    {
        verticalInput=Input.GetAxis("Vertical");
        horizontalInput=Input.GetAxis("Horizontal");
    }

    void ApplyBrakes()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            frontrightwheelcollider.brakeTorque = 1000f;
            backrightwheelcollider.brakeTorque = 1000f;
            frontleftwheelcollider.brakeTorque = 1000f;
            backleftwheelcollider.brakeTorque = 1000f;
        }
        else
        {
            frontrightwheelcollider.brakeTorque =0f;
            backrightwheelcollider.brakeTorque = 0f;
            frontleftwheelcollider.brakeTorque = 0f;
            backleftwheelcollider.brakeTorque = 0f;
        }
        
    }
    void Motorforce()
    {
        frontrightwheelcollider.motorTorque = motorForce * verticalInput;
        frontleftwheelcollider.motorTorque = motorForce * verticalInput;
    }
    void Steering()
    {
        frontrightwheelcollider.steerAngle = 30f * horizontalInput;
        frontrightwheelcollider.steerAngle = 30f * horizontalInput;

    }
    private void UpdateWheels()
    {
        RotateWheel(frontrightwheelcollider, frontrightwheeltransform);
        RotateWheel(backrightwheelcollider, backrightwheeltransform);
        RotateWheel(frontleftwheelcollider, frontleftwheeltransform);
        RotateWheel(backleftwheelcollider, backleftwheeltransform);
    }
    void RotateWheel(WheelCollider wheelcollider, Transform transform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelcollider.GetWorldPose(out pos, out rot);
        transform.position = pos;
        transform.rotation = rot;
    }
}
