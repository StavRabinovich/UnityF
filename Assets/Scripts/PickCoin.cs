using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // For text

public class PickCoin : MonoBehaviour
{
    public AudioSource pickSound;
    public Text coinsText;
    public static int numCoins;

    void Start()
    {
        numCoins = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        numCoins++;
        this.gameObject.SetActive(false); // Coin 
        pickSound.Play();
        coinsText.text = "Coins: " + numCoins;
    }
}
