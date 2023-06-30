using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private Transform target;
    private Vector3 _offset; 
    private float _cameraSpeed = 7f;
    private Vector3 _cameraProjection; // projection of the camera to the xy-plane of the player
    private Vector3 _newPosition; // new position of the camera, when the camera moves
    private float _maxDistance = 4f; // maximal distance between the camera projection and the player, before the camera starts moving
    private float _jumpDistance = 10f; // maximal distance between the camera projection and the player, before the camera jumps to the player

    void Start()
    {
        _offset = transform.position - target.transform.position;
        _cameraProjection = target.position;
        _newPosition = target.transform.position + _offset;
    }

    // We have not used LateUpdate() because the picture was jumpy when the camera followed the player
    void FixedUpdate()
    {
        // if player is not null, and the distance between the camera projection and the player is bigger than _jumpdistance the camera jumps to the player
        if (target != null && ((target.position - _cameraProjection).magnitude > _jumpDistance))
        {
            _cameraProjection = target.position;
            _newPosition = _cameraProjection + _offset;
            transform.position = _newPosition;
        }
        // else if player is not null, and the distance between the cameraProjection and the player is bigger than the _maxDistance the camera moves to the player
        
        else if(target != null && ((target.position - _cameraProjection).magnitude > _maxDistance))
        {
            // moves playerPosition to the position of player, with cameraSpeed
            _cameraProjection = Vector3.MoveTowards(_cameraProjection, target.position, Time.deltaTime * _cameraSpeed);
            // ADD OFFSET - to our position in order to depict the player properly
            _newPosition = _cameraProjection + _offset;
            // set the position of the camera to newPosition
            transform.position = _newPosition; 

        }

    }
}
