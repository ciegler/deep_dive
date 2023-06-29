using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform target;
    
    public Vector3 offset; // offset from the player position, so that the camera is not in the same xy-plane as the player and can therefore show the player
    


    private float cameraSpeed = 5f; 
    
    private Vector3 cameraProjection; // projection of the camera to the xy-plane of the player
    
    private Vector3 newPosition; // new position of the camera, when the camera moves
    
    private float maxDistance = 4f; // maximal distance between the camera projection and the player, before the camera starts moving

    void Start()
    {
        offset = transform.position - target.transform.position;
        cameraProjection = target.position;
        newPosition = target.transform.position + offset;
    }

    // LATEUPDATE - is called at the end of the frame 
    // 
    //void LateUpdate()
    void FixedUpdate()
    {
        // calculate distance
        //Vector3 distance = 
        // NULL CHECK  
        // if player is not null, and the distance between the cameraProjection and the player is bigger than the maxDistance
        if(target != null && ((target.position - cameraProjection).magnitude > maxDistance))
        {
            // moves playerPosition to the position of player, with cameraSpeed
            cameraProjection = Vector3.MoveTowards(cameraProjection, target.position, Time.deltaTime * cameraSpeed);
            // ADD OFFSET - to our position in order to depict the player properly
            newPosition = cameraProjection + offset;
            // set the position of the camera to newPosition
            transform.position = newPosition; 

        }
    }
}
