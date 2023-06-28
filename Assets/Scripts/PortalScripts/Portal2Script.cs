using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal2Script : MonoBehaviour
{
    // serialized field for the other portal
    [SerializeField] public GameObject otherPortal;
    
    
    private void OnTriggerEnter(Collider other)
    {
        // if there is a collision with the player call PlayerTeleportation
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PlayerTeleportation(otherPortal);
        }
    }
}
