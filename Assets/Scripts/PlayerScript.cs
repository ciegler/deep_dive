using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // variables 
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float _speed = 5f;
    
    
    bool _collided = true;
    private Vector3 _startPosition = new Vector3(0f, 0f, 0f);

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
        Debug.Log("Death");
        // transport back to start position
        transform.position = _startPosition;
        
        // set movement to 0
        RB.velocity = Vector3.zero;
        
        // display some text ...
    }
    
    /*
    public void PlayerTeleportation(otherPortal)
    {
        
    }
    */
}
