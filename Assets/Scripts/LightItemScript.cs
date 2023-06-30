using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class LightItemScript : MonoBehaviour
{
    /*
     * In level 3 the only light is the LightItem which can be collected by the player and then
     * follows the player through the level.
     */
    
    // Variables
    [SerializeField] [CanBeNull] private GameObject _player;
    [SerializeField] private Vector3 _startPosition;
    
    private bool _collected = false;

    // Functions
    private void Start()
    {
        Spawn();
    }
    
    // using LateUpdate to make game faster
    void LateUpdate()
    {
        // null check and collected check, so that the light follows the player only if it was collected
        if(_player != null && _collected)
        {
            // let the light follow the player
            Vector3 newPosition = _player.transform.position;
            transform.position = newPosition; 
        }
    }
    
    
    private void OnTriggerEnter(Collider other)
    {
        // set _collided to true when the player collides with the light
        if (other.CompareTag("Player"))
        {
            _collected = true;
        }
    }

    // Spawn() for the start of the level but also for respawning after the player died 
    public void Spawn()
    {
        transform.position = _startPosition;
        _collected = false;
    }
}
