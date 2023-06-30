using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightItemScript : MonoBehaviour
{
    
    [SerializeField] private GameObject player;
    [SerializeField] private Vector3 _startPosition;
    private bool _collected = false;

    private void Start()
    {
        Spawn();
    }


    // LATEUPDATE - is called at the end of the frame 
    void LateUpdate()
    {
        // NULL CHECK  
        if(player != null && _collected)
        {
            Debug.Log("light collected");
            // ADD OFFSET - to our position in order to depict the player properly
            Vector3 newPosition = player.transform.position;
            transform.position = newPosition; 
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _collected = true;

        }
    }

    public void Spawn()
    {
        transform.position = _startPosition;
    }
}
