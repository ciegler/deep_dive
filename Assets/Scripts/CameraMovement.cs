using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    // VARIABLES
    [SerializeField] private Transform target;
    private Vector3 _offset; 
    private float cameraSpeed = 7f;
    private Vector3 cameraProjection; // projection of the camera to the xy-plane of the player
    private Vector3 newPosition; // new position of the camera, when the camera moves
    private float maxDistance = 3f; // maximal distance between the camera projection and the player, before the camera starts moving
    private float _jumpDistance = 10f;

    //private Vector3 _yOffset = new Vector3(0f,3f,0f);

    void Start()
    {
        _offset = transform.position - target.transform.position;// - _yOffset;
        cameraProjection = target.position;
        newPosition = target.transform.position + _offset;
    }

    // LATEUPDATE - is called at the end of the frame 
    // 
    //void LateUpdate()
    void FixedUpdate()
    {
        // if the distance between the camera projection and the player is bigger than _jumpdistance the camera jumps to the player
        if (target != null && ((target.position - cameraProjection).magnitude > _jumpDistance))
        {
            cameraProjection = target.position;
            newPosition = cameraProjection + _offset;
            transform.position = newPosition;
        }
        // calculate distance
        //Vector3 distance = 
        // NULL CHECK  
        // if player is not null, and the distance between the cameraProjection and the player is bigger than the maxDistance
        
        else if(target != null && ((target.position - cameraProjection).magnitude > maxDistance))
        {
            // moves playerPosition to the position of player, with cameraSpeed
            cameraProjection = Vector3.MoveTowards(cameraProjection, target.position, Time.deltaTime * cameraSpeed);
            // ADD OFFSET - to our position in order to depict the player properly
            newPosition = cameraProjection + _offset;
            // set the position of the camera to newPosition
            transform.position = newPosition; 

        }

    }
}
