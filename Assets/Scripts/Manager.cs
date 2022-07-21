using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
  public AudioSource sons;
  public static Manager inst = null;

    void Awake ()
    {
        if (inst == null)
        {
            inst = this; 
        }else if ( inst != this)
        {
            Destroy(gameObject);
        }
    }

    public void PlayAudio (AudioClip music)
    {
        sons.clip = music;
        sons.Play ();
    }
}
