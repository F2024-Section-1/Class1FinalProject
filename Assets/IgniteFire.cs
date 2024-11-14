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
        if (other.CompareTag("Skull"))
        {
            Fire_01.Play() ; 
            Fire_02.Play() ;   
            Fire_03.Play() ;

            Debug.Log("Skull placed on the stick, fire ignited");

        }
    }
}
