using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class WinText: MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _winText;
    [SerializeField] private GameObject Player;

    private int _itemCount;

    
    public void ItemCount()
    {
        _itemCount = Player.GetComponent<PlayerScript>()._collectedItemsTotal.Count;

        Player.GetComponent<PlayerScript>().win.text = "You have won! You have collected " + _itemCount + " items. :)";
    }
}