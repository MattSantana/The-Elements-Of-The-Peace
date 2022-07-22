using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    [SerializeField]
    private Transform atkPoint;
    [SerializeField]
    private float atkRange; 

    public Animator anim;

    private int atkCombo = 1;
     private Cooldown nextAtk;
    private Cooldown finishCombo;

    void Start() {
        nextAtk = new Cooldown(0.33f, true);
        finishCombo = new Cooldown(0.71f, true);
     }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L) && nextAtk.IsFinished )
        {
            Attack();       
            Attacking();
        }
        if( finishCombo.IsFinished)
        {
            anim.SetBool("Attacking", false);
            atkCombo = 1;
        }  

    }
    private void Attack()
    {
        anim.SetBool("Attacking", true); 

        if (atkCombo == 1)
        {
            Debug.Log("Attack1");
            anim.SetTrigger("Attack1");
            atkCombo++;
        }
        else if ( atkCombo == 2)
        {
            Debug.Log("Attack2");
            anim.SetTrigger("Attack2");
            atkCombo = 1;
        }
        nextAtk.Start();
        finishCombo.Start();
    }
    // Serve pra desenhar algumas formas na cena da Unity.
    private void OnDrawGizmos() {
        if( this.atkPoint != null)
        {
        Gizmos.DrawWireSphere(this.atkPoint.position, this.atkRange);
        }
    }

    private void Attacking()
    {
        Collider2D colliderEnemy = Physics2D.OverlapCircle( this.atkPoint.position, this.atkRange );
        if( colliderEnemy != null)
        {   
            // Executa a busca de um script no inimigo que esteja no objeto do colider. 
            EnemyTakeDamage enemy = colliderEnemy.GetComponent<EnemyTakeDamage>();

            // Salvamos o valor da busca em Enemy. Se o valor do script for diferente de nulo, ele chama a função takeDamage.
            if (enemy != null)
            {
            enemy.takeDamage();
            }
        }
    } 
}
