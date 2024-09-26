using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    private int diamonds_value = 0;
    private int gold_value = 0;
    private int emeralt_value = 0;

    private int player_value = 100;


    [SerializeField] private TextMeshProUGUI diamonds;
    [SerializeField] private TextMeshProUGUI gold;
    [SerializeField] private TextMeshProUGUI emeralt;
    [SerializeField] private TextMeshProUGUI player;

    private void Update()
    {
        diamonds.text = diamonds_value.ToString();
        gold.text = diamonds_value.ToString();
        emeralt.text = diamonds_value.ToString();
        player.text = player_value.ToString() + "$";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "diamond ore")
        {
            diamonds_value++;
        }
        if (collision.gameObject.tag == "gold ore")
        {
            gold_value++;
        }
        if (collision.gameObject.tag == "emeralt ore")
        {
            emeralt_value++;
        }
    }

}
