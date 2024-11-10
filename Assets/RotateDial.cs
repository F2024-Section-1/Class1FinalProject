using UnityEngine;

public class RotateDial : MonoBehaviour
{
    public float rotationSpeed = 50f;
    private bool isInteracting = false;

    void Update()
    {
        if (isInteracting)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PlayerHand"))
        {
            isInteracting = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        isInteracting = false;
    }
}
