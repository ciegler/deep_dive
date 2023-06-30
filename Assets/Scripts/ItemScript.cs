using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    /*
     * The Item can be collected by the player, the position can be adjusted via a serialized field 
     */
    
    // Variables
    [SerializeField] private Vector3 _startPosition;

    private void Start()
    {
        Spawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        // when the player collides with the item collect the item
        // and move it out of the visible bounds (important for the respawn)
        if (other.CompareTag("Player"))
        {
           other.GetComponent<PlayerScript>().CollectItem(this.GameObject());
           transform.position = new Vector3(0f,0f,1000f); 

        }
    }

    // Spawn() for Start() and respawn when player dies
    public void Spawn()
    {
        transform.position = _startPosition;
    }
    
}
