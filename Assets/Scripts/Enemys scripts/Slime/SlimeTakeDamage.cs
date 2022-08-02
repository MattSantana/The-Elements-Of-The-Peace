using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTakeDamage : MonoBehaviour
{
  [SerializeField]
  private int life;

  [SerializeField]
  public Animator anim;
  [SerializeField]
  private float timeDeath;
  [SerializeField]
  private GameObject coins;

  public void slimeDamage()
  {
    this.life--;
    Debug.Log (this.name + "recebeu dano. Vida: " + this.life);

    if (this.life == 0)
    {
      //finalizado
      this.anim.SetBool("SlimeDeath", true);  
      Destroy(gameObject, timeDeath );
      Instantiate(coins, this.gameObject.transform.position, Quaternion.identity );
    }else{
      //recebe dano
      this.anim.SetTrigger("SlimeTakeHit");
    }
  }
}
