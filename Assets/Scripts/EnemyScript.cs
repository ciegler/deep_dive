using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _upperRightBound;
    [SerializeField] private Vector3 _lowerLeftBound;

    private float _speed = 5f;
    
    void Start()
    {
        transform.position = _startPosition;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        // if y == y and x < x:
        // move in x direction
        // ...?
        

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PlayerDeath();
        }
    }
}
