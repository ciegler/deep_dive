using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // variables 
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float _speed = 5f;
    
    
    bool collided = true;

    // Start is called before the first frame update
    void Start()
    {
        // START POSITION
        transform.position = new Vector3(0f,0f,0f);
    }

    // Update is called once per frame
    void Update()
    {
        
        

        // MOVEMENT
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // if the space bar is pressed the player should stop
        if (Input.GetKeyDown(KeyCode.Space) && collided) {
            RB.velocity = Vector3.zero;
            collided = false;
        }
                
        // if the spacebar is released the player will move
        if (Input.GetKeyUp(KeyCode.Space)){
            RB.AddForce(Vector3.right * horizontalInput * _speed, ForceMode.Impulse);
            RB.AddForce(Vector3.up * verticalInput * _speed, ForceMode.Impulse);
            
        } else {
            RB.velocity = (RB.velocity.magnitude == 0 ? 
                        Vector3.zero : RB.velocity.normalized) * _speed;
        }
        
    }

    void OnCollisionEnter(Collision collision)
    {
        collided = true;
    }
}
