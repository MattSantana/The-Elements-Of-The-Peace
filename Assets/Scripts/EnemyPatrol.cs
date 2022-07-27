using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField]
    private Transform target;
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


    void Update()
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
          this.anim.SetBool("SlimeRun", true);

        }else{ // para a movimentação se chegar no limite de distância definido por Finish Line.
          this.monsters.velocity = Vector2.zero;
          this.anim.SetBool("SlimeRun", false);
        }


    }
}
