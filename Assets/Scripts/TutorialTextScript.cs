using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialTextScript : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _tutorialText;
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _tutorialText.enabled = false;
        }
    }
}
