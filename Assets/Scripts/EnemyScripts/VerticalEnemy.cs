using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalEnemy : MonoBehaviour
{
    // Start is called before the first frame update
    
    private Vector3 _UpperPosition = Vector3.zero;
    private Vector3 _LowerPosition = Vector3.zero;

    private Vector3 _distance = new Vector3(0f, 3f, 0f);
    [SerializeField] private Vector3 _startPosition;
    private bool _down = true;
    
    

    private float _speed = 1f;
    
    void Start()
    {
        transform.position = _startPosition;

        _UpperPosition = _startPosition;
        _LowerPosition = _startPosition - _distance;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMovement();
    }

    private void EnemyMovement()
    {
        // variables for movement
        if (_down)
        {
            transform.position = Vector3.MoveTowards(transform.position, _LowerPosition, _speed * Time.deltaTime);
            
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, _UpperPosition, _speed * Time.deltaTime);
        }

        if (transform.position == _LowerPosition)
        {
            _down = false;
        }

        if (transform.position == _UpperPosition)
        {
            _down = true;
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
