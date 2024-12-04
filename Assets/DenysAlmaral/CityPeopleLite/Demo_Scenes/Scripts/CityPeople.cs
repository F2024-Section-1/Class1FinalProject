using System.Collections;
using UnityEngine;
using UnityEngine.AI; // Make sure to add this for navigation

namespace CityPeople
{
    public class CityPeople : MonoBehaviour
    {
        private AnimationClip[] myClips;
        private Animator animator;
        private NavMeshAgent navMeshAgent;  // To handle movement
        private Vector3 targetPosition;     // The next random target position for the character
        private float moveSpeed = 2f;       // Speed of movement

        void Start()
        {
            animator = GetComponent<Animator>();
            navMeshAgent = GetComponent<NavMeshAgent>();  // Get NavMeshAgent component for movement

            if (animator != null)
            {
                myClips = animator.runtimeAnimatorController.animationClips;
                PlayAnyClip();
                StartCoroutine(ShuffleClips());
            }

            // Start a coroutine to move to a random position
            StartCoroutine(RoamAround());
        }

        void PlayAnyClip()
        {
            var cl = myClips[Random.Range(0, myClips.Length)];
            animator.CrossFadeInFixedTime(cl.name, 1.0f, -1, Random.value * cl.length);
        }

        IEnumerator ShuffleClips()
        {
            while (true)
            {
                yield return new WaitForSeconds(15.0f + Random.value * 5.0f);
                PlayAnyClip();
            }
        }

        // Coroutine for random roaming movement
        IEnumerator RoamAround()
        {
            while (true)
            {
                // Wait for a random period before moving
                yield return new WaitForSeconds(Random.Range(3.0f, 6.0f));

                // Get a random position within the bounds of the NavMesh
                SetRandomDestination();
            }
        }

        // Function to set a random target position
        void SetRandomDestination()
        {
            // You can adjust the range or use a different strategy for selecting random positions.
            // Here we are picking a random position within a defined area.
            float x = Random.Range(-10f, 10f); // Set X axis range for movement
            float z = Random.Range(-10f, 10f); // Set Z axis range for movement
            targetPosition = new Vector3(x, transform.position.y, z); // Keep Y the same to avoid vertical movement

            // Move the NavMeshAgent to the target position
            navMeshAgent.SetDestination(targetPosition);
        }

        void Update()
        {
            // Optionally, add logic to switch animations based on the movement (walking/running animation).
            if (navMeshAgent.velocity.magnitude > 0.1f)
            {
                // The character is moving, play walking/running animation (if available).
                if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Walk") &&
                    !animator.GetCurrentAnimatorStateInfo(0).IsName("Run"))
                {
                    PlayAnyClip(); // Random animation during movement
                }
            }
            else
            {
                // Character is idle, you can play idle animation if needed
                PlayAnyClip();
            }
        }
    }
}
