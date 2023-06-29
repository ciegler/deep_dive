using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 _distance = new Vector3(0f, 3f, 0f);
    [SerializeField] private Vector3 _startPosition;

    [SerializeField] private Vector3 _secondPosition;
    private bool _hinzus = true;
    private float _speed = 1f;
    
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
        // variables for movement
        if (_hinzus)
        {
            transform.position = Vector3.MoveTowards(transform.position, _secondPosition, _speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _startPosition, _speed * Time.deltaTime);
        }

        if (transform.position == _secondPosition)
        {
            _hinzus = false;
        }

        if (transform.position == _startPosition)
        {
            _hinzus = true;
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
