using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.Serialization;

public class PlayerScript : MonoBehaviour
{
    /*
     * The player has a lot of different functionalities:
     * - a specific movement
     * - teleportation
     * - can collect items
     * - death
     * which are all implemented in the PlayerScript
     */
    
    
    // VARIABLES
    
    [SerializeField] private Rigidbody RB;
    [SerializeField] private Vector3 startPosition;

    // variables for movement
    private float _speed = 6f;
    private bool _collided = true;
 
    // variables for teleportation
    private float _coolDownTeleport = 1f;
    private float _nextTeleportTime = 0.5f;

    // lists for collection of items
    public List<GameObject> collectedItemsTotal = new List<GameObject>();
    private List<GameObject> _collectedItemsCurrentScene = new List<GameObject>();

    // for respawning objects after death
    private GameObject[] _enemyRespawns;
    private GameObject[] _itemRespawns;
    private GameObject[] _lightRespawns;
    

    // FUNCTIONS
    void Start()
    {
        // set start position
        transform.position = startPosition;
       
    }
    void Update()
    {
        PlayerMovement();
    }

    /*
     * Functions connected to player movement:
     * - the player should be able to move horizontally, vertically and diagonally with a constant speed
     * - the player should only be able to stop if it collided with a wall
     * - the player should be able to teleport through a portal
     */
    
    private void OnCollisionEnter(Collision collision)
    {
        // set _collided to true when the player collided
        _collided = true;
    }

    private void PlayerMovement()
    {
        // get horizontal and vertical input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // if the space bar is pressed the player should stop
        // this is only possible after colliding with a wall
        if (Input.GetKeyDown(KeyCode.Space) && _collided) {
            RB.velocity = Vector3.zero;
            _collided = false;
        }
        
                
        // if the space bar is released the player will move
        if (Input.GetKeyUp(KeyCode.Space)){
            RB.AddForce(Vector3.right * horizontalInput * _speed, ForceMode.Impulse);
            RB.AddForce(Vector3.up * verticalInput * _speed, ForceMode.Impulse);
            
        } else {
            // the player should not get faster if the arrow keys are pressed again
            RB.velocity = (RB.velocity.magnitude == 0 ? 
                Vector3.zero : RB.velocity.normalized) * _speed;
        }
        
    }
    public void PlayerTeleportation(GameObject otherPortal)
    {
        // the player should teleport to the otherPortal
        if (_nextTeleportTime < Time.time)
        {
            transform.position = otherPortal.transform.position;
            _nextTeleportTime = Time.time + _coolDownTeleport;
        }
        
    }
    
    
    // Functions connected to the player's death
    public void PlayerDeath()
    {
        // transport back to start position
        transform.position = startPosition;
        
        // set movement to 0
        RB.velocity = Vector3.zero;
        
        // respawn enemies and items
        RespawnObjects();
        
        // delete all collected items from this level
        _collectedItemsCurrentScene.Clear();
    }

    // Functions for respawning after the player's death
    private void RespawnObjects()
    {
        RespawnEnemies();
        RespawnItems();
        RespawnLight();
    }
    private void RespawnEnemies()
    {
        // search for all enemies in scene
        if (_enemyRespawns == null)
        {
            _enemyRespawns = GameObject.FindGameObjectsWithTag("Enemy");
        }
        
        // respawn the enemies
        foreach (GameObject enemy in _enemyRespawns)
        {
            enemy.GetComponent<EnemyScript>().Spawn();
        }
    }
    private void RespawnItems()
    {
        // search for all items in scene
        if (_itemRespawns == null)
        {
            _itemRespawns = GameObject.FindGameObjectsWithTag("Item");
        }
        
        // respawn the items
        foreach (GameObject item in _itemRespawns)
        {
            item.GetComponent<ItemScript>().Spawn();
        }
    }
    private void RespawnLight()
    {
        // important only for level 3
        
        // search for the light item in scene
        if (_lightRespawns == null)
        {
            _lightRespawns = GameObject.FindGameObjectsWithTag("Light");
        }
        
        // respawn the light item 
        foreach (GameObject light in _lightRespawns)
        {
            light.GetComponent<LightItemScript>().Spawn();
        }
    }

    // Functions for collecting the items
    public void CollectItem(GameObject item)
    {   
        // collect items in current scene after collision
        _collectedItemsCurrentScene.Add(item);
    }

    public void SaveItems()
    {
        // save the collected items from current scene (if player collides with the scenechanger)
        if (_collectedItemsCurrentScene.Count() != 0)
        {
            collectedItemsTotal.AddRange(_collectedItemsCurrentScene);
            Debug.Log(collectedItemsTotal.Count());
        }
    }
    
}
