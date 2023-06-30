using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapWallScript : MonoBehaviour
{
    // when colliding with a TrapWall the Player dies
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PlayerDeath();
        }
    }
}
