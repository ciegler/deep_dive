using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    /*
     * SceneChanger to get to the next level
     */
    
    // Variables
    private int _sceneNumber;
    
    // Functions
    void Start()
    {
        _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        // switch to the next level if player collides with this
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene(_sceneNumber+1);
            other.GetComponent<PlayerScript>().SaveItems();
        }
        
    }

    
    public void Restart()
    {
        // after winning the game:
        // restarts the first game scene, when the player presses the button to do so
        // unpauses the time
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}