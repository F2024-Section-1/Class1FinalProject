using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    [SerializeField] private int garage; // Name of the next scene

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        SceneManager.LoadScene(garage);
        // Check if the colliding object is the player
        if (other.CompareTag("Player"))
        {
                
            Debug.Log("test test test");
        }
    }
}
