using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
           other.GetComponent<PlayerScript>().CollectItem(this.GameObject());
               Destroy(this.GameObject()); 

        }
    }
    
}
