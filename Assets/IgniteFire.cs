using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgniteFire : MonoBehaviour
{
    public ParticleSystem Fire_01;
    public ParticleSystem Fire_02;
    public ParticleSystem Fire_03;

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object entering the trigger has the "Skull" tag
        if (other.CompareTag("Skull"))
        {
            Debug.Log("Skull placed on the stick, enabling fire...");

            // Ensure fire is enabled and playing
            EnableAndPlayFire(Fire_01);
            EnableAndPlayFire(Fire_02);
            EnableAndPlayFire(Fire_03);
        }
    }

    private void EnableAndPlayFire(ParticleSystem fireSystem)
    {
        if (!fireSystem.gameObject.activeSelf)
        {
            fireSystem.gameObject.SetActive(true); // Enable the fire object
        }
        fireSystem.Play(); // Play the fire particle system
    }
}
