using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class TutorialTextScript : MonoBehaviour
{
    /*
     * Make the text in the tutorial invisible after the player presses space
     */
    
    // Variables
    [SerializeField] private TextMeshProUGUI tutorialText;
    
    // Functions
    void Update()
    {
        // disable the text if the player presses enter
        if (Input.GetKeyDown(KeyCode.Space))
        {
            tutorialText.enabled = false;
        }
    }
}
