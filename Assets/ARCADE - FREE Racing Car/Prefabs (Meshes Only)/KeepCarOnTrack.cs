using UnityEngine;

public class KeepCarOnTrack : MonoBehaviour
{
    public float maxHeight = 5.0f;

    void Update()
    {
        if (transform.position.y > maxHeight)
        {
            transform.position = new Vector3(transform.position.x, 0.2f, transform.position.z);
        }
    }
}
