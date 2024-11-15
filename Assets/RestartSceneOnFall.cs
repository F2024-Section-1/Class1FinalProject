using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartSceneOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // The Y position at which the scene should restart

    void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold)
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
