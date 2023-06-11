using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // variables 
    [SerializeField] private Rigidbody RB;
    [SerializeField] private float _speed = 5f;

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
        

        // horizontal
        
        if (Input.GetKeyDown("space"))
            RB.velocity = Vector3.zero;
        
        if(horizontalInput < 0 && RB.velocity.x >= 0 ||
            horizontalInput > 0 && RB.velocity.x <= 0)
            RB.velocity = Vector3.zero;

        RB.AddForce(Vector3.right * horizontalInput * _speed, ForceMode.Impulse );

        if(verticalInput < 0 && RB.velocity.x >= 0 ||
            verticalInput > 0 && RB.velocity.x <= 0)
            RB.velocity = Vector3.zero;

        RB.AddForce(Vector3.up * verticalInput * _speed, ForceMode.Impulse );
        
        RB.velocity = (RB.velocity.magnitude == 0 ? 
                        Vector3.zero : RB.velocity.normalized) * _speed;
        
    }
}
