using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Speed of the camera movement
    public float moveSpeed = 10f;

    void Update()
    {
        // Get horizontal input (A/D or left/right arrows) for X axis
        float moveX = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;

        // Get vertical input (W/S or up/down arrows) for Z axis
        float moveZ = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        // Only change the X and Z position, Y stays fixed
        transform.position = new Vector3(transform.position.x + moveX, transform.position.y, transform.position.z + moveZ);
    }
}
