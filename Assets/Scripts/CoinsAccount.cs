using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsAccount : MonoBehaviour
{
    private int coins = 0;
    //Audio coins
    public AudioClip coinsSound;

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
            Manager.inst.PlayAudio(coinsSound); 
            Destroy(other.gameObject);
            
        }
   }
}
