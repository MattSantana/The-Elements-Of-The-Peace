using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem1Patrol : MonoBehaviour
{
    #region//Variáveis pra movimentar o vilão até o jogador e animação.
   
    [SerializeField]
    private float moveSpeed;
    [SerializeField]
    private float finishLine;
    [SerializeField]
    private Rigidbody2D monsters;
    [SerializeField]
    private SpriteRenderer sprite;
    [SerializeField]
    private Animator anim;
    #endregion

    private Transform target;

    //Variáveis para definir alcance de visão dos inimigos.
    [SerializeField]
    private float visionRange;
    [SerializeField]
    private LayerMask layerTarget;

    //Variáveis pra definir alcance de ataque
    [SerializeField]
    private bool atkPoint;

void Start() {
  Physics2D.IgnoreLayerCollision(3,3);
}
void Update()
  { 
    searchPlayer();
    atkPoint = Physics2D.OverlapCircle( this.transform.position, this.visionRange/3, this.layerTarget );
    if(!atkPoint == false )
    {
      if( this.target != null)
     {
      move();
     }else{
      stopMove();
     }      
    }

  }

  private void OnDrawGizmos() {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange );
        Gizmos.color = Color.red;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange/3);
  }
  private void searchPlayer()
  {
    // O método OverlapCircle retorna um colisor, por isso associei ele com a variável collider2d.
    Collider2D collider = Physics2D.OverlapCircle( this.transform.position, this.visionRange, this.layerTarget );

    if( collider != null )
    {
      this.target = collider.transform;
    }else {
      this.target = null;
    }
    }

  private void move()
  {
    // Função para calcular a direção entre o alvo e o inimigo. 
    Vector2 targetPosition = this.target.position;
    Vector2 atualPosition = this.transform.position;

    float distance = Vector2.Distance( atualPosition, targetPosition);
    if( distance >= this.finishLine)
    {
      //Mover o Inimigo
      Vector2 direction = targetPosition - atualPosition;
      // Normalizamos o valor para saber apenas a direção até o alvo, e não a distância. 
      direction = direction.normalized; 

      // converti o valor do Vector2 em float, para poder zerar o valor da movimentação em Y.
      float x = direction.x;

      this.monsters.velocity = new Vector2( x * moveSpeed , 0 );

      if(this.monsters.velocity.x > 0 )
      {
        this.sprite.flipX = false;
      }
      else if (this.monsters.velocity.x < 0)
      {
        this.sprite.flipX = true;           
      }
      this.anim.SetBool("Golem1Run", true);
    }
    else{
      stopMove();
    }
  }
  private void stopMove()
    {
      // para a movimentação se chegar no limite de distância definido por Finish Line.
      this.monsters.velocity = Vector2.zero;
      this.anim.SetBool("Golem1Run", false);      
    }

}
