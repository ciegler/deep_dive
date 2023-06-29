using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private int _sceneNumber;
    void Start()
    {
    _sceneNumber = SceneManager.GetActiveScene().buildIndex;
    Debug.Log(_sceneNumber);
    }
  

    // switch to next level
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(_sceneNumber+1);
    }

    // restarts the first game scene, when the player presses the button to do so after winning the game
    // unpauses the time
    public void Restart()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
}