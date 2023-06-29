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
}