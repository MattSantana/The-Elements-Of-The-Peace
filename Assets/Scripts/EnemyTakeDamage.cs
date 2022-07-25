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
    Debug.Log (this.name + "recebeu dano. Vida: " + this.life);

    if (this.life == 0)
    {
      //finalizado
      this.anim.SetBool("Golem1Death", true);
      this.anim.SetBool("SlimeDeath", true);  
      this.anim.SetBool("Golem2Death", true);
    }else{
      //recebe dano
      this.anim.SetTrigger("Golem1TakeHit");
      this.anim.SetTrigger("SlimeTakeHit");
      this.anim.SetTrigger("Golem2TakeHit");
    }
  }
}
