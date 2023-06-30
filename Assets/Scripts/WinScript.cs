using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class WinScript: MonoBehaviour
{
    /*
     * The text that is displayed when the player wins,
     * counts the items that were collected during the game.
     */
    
    // Variables
    [SerializeField] private TextMeshProUGUI winText;
    [SerializeField] private GameObject player;

    private List<GameObject> _itemList;
    private int _itemCount;

    
    // Functions
    public void ItemCount()
    {
        player.GetComponent<PlayerScript>().SaveItems();
        _itemList = new List<GameObject>(player.GetComponent<PlayerScript>().collectedItemsTotal);
        _itemCount = _itemList.Count();
        winText.text = "You have won! You have collected " + _itemCount + " items. :)";
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            // display text and pause the game
            ItemCount();
            winText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }
}