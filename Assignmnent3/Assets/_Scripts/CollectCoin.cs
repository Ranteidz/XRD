using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    public int coins;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            coins = coins + 1;
            other.gameObject.SetActive(false);
            Destroy(other.gameObject);
        }
        InformationUIController.SetCoinsCollected(coins);
    }
}
