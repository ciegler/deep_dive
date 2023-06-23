using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovement : MonoBehaviour
{
    // IDEA - Camera should follow the player which is our target here 
    [SerializeField] private Transform target;
    public Vector3 offset;
    private float _max_distance = 5;


    void Start()
    {
        offset = transform.position - target.transform.position; 
    }

    // LATEUPDATE - is called at the end of the frame 
    void LateUpdate()
    {
        // calculate distance
        //Vector3 distance = 
        // NULL CHECK  
        if(target != null)
        {
            // ADD OFFSET - to our position in order to depict the player properly
            Vector3 newPosition = target.transform.position + offset;
            transform.position = newPosition; 
        }
    }
}
