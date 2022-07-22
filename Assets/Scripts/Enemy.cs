using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  [SerializeField]
  private int life;

  public void takeDamage()
  {
    this.life--;
    if (this.life == 0)
    {
       GameObject.Destroy(this.gameObject);
    }
  }
}
