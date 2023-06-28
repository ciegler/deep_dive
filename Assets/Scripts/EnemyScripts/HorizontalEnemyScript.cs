using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HorizontalEnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 _RightPosition = Vector3.zero;
    private Vector3 _LeftPosition = Vector3.zero;

    private Vector3 _distance = new Vector3(5f, 0f, 0f);
    [SerializeField] private Vector3 _startPosition;
    private bool _toleft = true;
    
    

    private float _speed = 1f;
    
    void Start()
    {
        transform.position = _startPosition;

        _RightPosition = _startPosition;
        _LeftPosition = _startPosition - _distance;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        // variables for movement
        if (_toleft)
        {
            transform.position = Vector3.MoveTowards(transform.position, _LeftPosition, _speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _RightPosition, _speed * Time.deltaTime);
        }

        if (transform.position == _LeftPosition)
        {
            _toleft = false;
        }

        if (transform.position == _RightPosition)
        {
            _toleft = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerScript>().PlayerDeath();
        }
    }
}