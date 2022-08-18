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

  private Rigidbody2D rb;
  private GameObject player;
  public float kbForce;


    void Start()
    {
      anim = GetComponent<Animator>();
      rb = GetComponent<Rigidbody2D>();

      player = GameObject.FindGameObjectWithTag("Player");
    } 

  public void slimeDamage()
  {
    TakingDamage();

    this.life--;
    Debug.Log (this.name + "recebeu dano. Vida: " + this.life);

    if (this.life == 0)
    {
      //finalizado
      this.anim.SetBool("SlimeDeath", true);  
    }else{
      //recebe dano
      this.anim.SetTrigger("SlimeTakeHit");
    }
  }
  public void destroyEnemy()
  {
    Destroy(gameObject);
    Instantiate(coins, this.gameObject.transform.position, Quaternion.identity );

  }
  void TakingDamage()
  {
    Vector2 difference = (transform.position - player.transform.position).normalized;
    Vector2 force = difference * kbForce;
    rb.AddForce(force, ForceMode2D.Impulse);

    Debug.Log("Aqui");
  }  
}
