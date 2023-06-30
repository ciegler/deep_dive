using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;


public class CameraMovement : MonoBehaviour
{
    /*
     * The camera should follow the player only if it moved a fixed distance away from the camera
     * position. When the player is too far away (e.g. through teleportation) the camera should
     * jump instead of move to the player's position.
     */
    
    // Variables
    [SerializeField] private Transform target;
    
    private Vector3 _offset; 
    private Vector3 _cameraProjection; 
    private Vector3 _newPosition;
    
    private float _cameraSpeed = 7f;
    private float _maxDistance = 4f; 
    private float _jumpDistance = 7f;

    // Functions 
    void Start()
    {
        // calculate _offset, _cameraProjection, _newPosition
        _offset = transform.position - target.transform.position;
        _cameraProjection = target.position;
        _newPosition = target.transform.position + _offset;
    }

    // Using FixedUpdate, since LateUpdate made the picture jumpy
    void FixedUpdate()
    {
        // the camera follows the player if it moves out of a certain bound (_maxDistance)
        if(target != null && ((target.position - _cameraProjection).magnitude > _maxDistance))
        {
            // calculate new _cameraProjection and move to it 
            _cameraProjection = Vector3.MoveTowards(_cameraProjection, target.position, Time.deltaTime * _cameraSpeed);
            _newPosition = _cameraProjection + _offset;
            transform.position = _newPosition; 

        }
        // if the player is too far away (through teleportation), jump to its new position
        if (target != null && ((target.position - _cameraProjection).magnitude > _jumpDistance))
        {
            _cameraProjection = target.position;
            _newPosition = _cameraProjection + _offset;
            transform.position = _newPosition;
        }
        
    }
}
