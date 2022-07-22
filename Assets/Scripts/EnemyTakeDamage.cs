using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour
{
  [SerializeField]
  private int life;

  [SerializeField]
  public Animator anim;

  public void takeDamage()
  {
    this.life--;

    anim.SetBool("SlimeTakeHit", true);


    if (this.life == 0)
    {
      //finalizado
      this.anim.SetBool("SlimeDeath", true);
    }else{
      //recebe dano
      this.anim.SetTrigger("SlimeTakeDamage");
    }
  }
}
