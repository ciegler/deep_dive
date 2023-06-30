using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;

    private void Start()
    {
        Spawn();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.GetComponent<PlayerScript>().CollectItem(this.GameObject());
           transform.position = new Vector3(0f,0f,1000f); 

        }
    }

    public void Spawn()
    {
        transform.position = _startPosition;
    }
    
}
