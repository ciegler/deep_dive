using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class PlayerScript : MonoBehaviour
{
    // VARIABLES

    [SerializeField] private Rigidbody RB;
    [SerializeField] private Vector3 _startPosition;

    // variables for movement
    [SerializeField] private float _speed = 5f;
    private bool _collided = true;
 
    // variables for teleportation
    private float _coolDownTeleport = 1f;
    private float _nextTeleportTime = 0.5f;

    // lists for collection of items
    private List<GameObject> _collectedItemsTotal = new List<GameObject>();
    private List<GameObject> _collectedItemsCurrentScene = new List<GameObject>();

    // for respawning objects after death
    private GameObject[] _enemyRespawns;
    private GameObject[] _itemRespawns;
    private GameObject[] _lightRespawns;
    
// text that shows if you win the game
    [SerializeField] private TextMeshProUGUI win;


    // Start is called before the first frame update
    void Start()
    {
        // START POSITION
        transform.position = _startPosition;
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collided = true;
    }

    private void PlayerMovement()
    {
        // variables for movement
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
            RB.velocity = (RB.velocity.magnitude == 0 ? 
                Vector3.zero : RB.velocity.normalized) * _speed;
        }
        
    }

    public void PlayerDeath()
    {
        // transport back to start position
        transform.position = _startPosition;
        
        // set movement to 0
        RB.velocity = Vector3.zero;
        
        // respawn enemies and items
        RespawnObjects();
        
        // delete all collected items from this level
        _collectedItemsCurrentScene.Clear();
    }
    
    
    public void PlayerTeleportation(GameObject otherPortal)
    {
        if (_nextTeleportTime < Time.time)
        {
            transform.position = otherPortal.transform.position;
            _nextTeleportTime = Time.time + _coolDownTeleport;
        }
        
    }

    public void CollectItem(GameObject item)
    {
        _collectedItemsCurrentScene.Add(item);
    }

    public void SaveItems()
    {
       
        _collectedItemsTotal.AddRange(_collectedItemsCurrentScene);
        Debug.Log("items saved");
        Debug.Log(_collectedItemsTotal[0]);
            
        
    }
    
    
    private void OnTriggerEnter(Collider collision)
    {
        // triggers when player wins the game
        // activates win screen and pauses the game
        if (collision.tag == "win")
        {
            win.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void RespawnObjects()
    {
        RespawnEnemies();
        RespawnItems();
        RespawnLight();
    }
    private void RespawnEnemies()
    {
        if (_enemyRespawns == null)
        {
            _enemyRespawns = GameObject.FindGameObjectsWithTag("Enemy");
        }
        

        foreach (GameObject enemy in _enemyRespawns)
        {
            enemy.GetComponent<EnemyScript>().Spawn();
        }
    }
    private void RespawnItems()
    {
        if (_itemRespawns == null)
        {
            _itemRespawns = GameObject.FindGameObjectsWithTag("Item");
        }
        

        foreach (GameObject item in _itemRespawns)
        {
           item.GetComponent<ItemScript>().Spawn();
        }
    }
    private void RespawnLight()
    {
        if (_lightRespawns == null)
        {
            _lightRespawns = GameObject.FindGameObjectsWithTag("Light");
        }
        

        foreach (GameObject light in _lightRespawns)
        {
            light.GetComponent<LightItemScript>().Spawn();
        }
    }
}
