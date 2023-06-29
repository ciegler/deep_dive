using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // VARIABLES
    
    [SerializeField] private Rigidbody RB;
    private Vector3 _startPosition = new Vector3(0f, 0f, 0f);
    
    // variables for movement
    [SerializeField] private float _speed = 5f;
    private bool _collided = true;
    private MaterialPropertyBlock _mpb;
    private float _colorChannel = 0.5f;
        
    // variables for teleportation
    private float _coolDownTeleport = 1f;
    private float _nextTeleportTime = 0.5f;
    
    // list of collected items
    private List<GameObject> _collectedItems = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        // START POSITION
        transform.position = _startPosition;
        
        if (_mpb == null)
        {
            _mpb = new MaterialPropertyBlock();
            _mpb.Clear();

        }
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
        
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        _collided = true;
        //change color
        Debug.Log("collided = true");
        _colorChannel -= 0.2f;
        _mpb.SetColor("Color", new Color(_colorChannel, 0.5f,0.5f, 1f));
        this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
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
            // change color
            _colorChannel += 0.2f;
            Debug.Log(_colorChannel);
            _mpb.SetColor("Color",new Color(_colorChannel, _colorChannel,0.5f, 1f));
            this.GetComponent<Renderer>().SetPropertyBlock(_mpb);
        }
        
                
        // if the space bar is released the player will move
        if (Input.GetKeyUp(KeyCode.Space)){
            RB.AddForce(Vector3.right * horizontalInput * _speed, ForceMode.Impulse);
            RB.AddForce(Vector3.up * verticalInput * _speed, ForceMode.Impulse);
            
        } else {
            RB.velocity = (RB.velocity.magnitude == 0 ? 
                Vector3.zero : RB.velocity.normalized) * _speed;
        }
        
        // TODO change color when collided 
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
        _collectedItems.Add(item);
        Debug.Log(_collectedItems[0].tag);
    }

    private void TurnOnFlashlight()
    {
        // in der liste nach flashligh suchen
        
    }
    
    // TODO : activate flashlight if item is in possession 
    
}
