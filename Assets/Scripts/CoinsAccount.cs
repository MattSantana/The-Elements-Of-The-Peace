using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsAccount : MonoBehaviour
{
    private int coins = 0;
    //Audio coins
    public AudioClip coinsSound;
    public Text txtCoins;

    void Start()
    {  
    }

    void Update()
    {    
    }
    
  private void OnTriggerEnter2D(Collider2D other) 
   {
        if( other.gameObject.CompareTag("Coins"))
        {
            // soma moedas
            coins++;
            txtCoins.text = coins.ToString();
            Manager.inst.PlayAudio(coinsSound); 
            Destroy(other.gameObject);
            
        }
   }
}
