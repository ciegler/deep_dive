using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyScript : MonoBehaviour
{
    /*
     * The enemies are designed to move between two points. The points are adjustable for each
     * enemy via serialized fields in the unity engine.
     */
   
    // Variables
    [SerializeField] private Vector3 startPosition;
    [SerializeField] private Vector3 secondPosition;
    
    private Vector3 _distance = new Vector3(0f, 3f, 0f);
    private bool _towards = true;
    private float _speed = 1f;
    
    
    // Functions
    void Start()
    {
        Spawn();
    }

    void Update()
    {
        EnemyMovement();
    }
    
    

    private void EnemyMovement()
    {
        // the enemy always moves between two points
        if (_towards)
        {
            transform.position = Vector3.MoveTowards(transform.position, secondPosition, _speed * Time.deltaTime);
        } else {
            transform.position = Vector3.MoveTowards(transform.position, startPosition, _speed * Time.deltaTime);
        }
        
        // change the boolean _towards to change the direction of the enemy
        if (transform.position == secondPosition)
        {
            _towards= false;
        } 
        else if (transform.position == startPosition)
        {
            _towards = true;
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // when player collides with an enemy the player dies
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PlayerDeath();
        }
    }

    // Spawn() for Start() and for respawning after the player died
    public void Spawn()
    {
        transform.position = startPosition;
    }
}
