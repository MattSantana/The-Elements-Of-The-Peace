using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAtack : MonoBehaviour
{
    //Aplicação de dano
    [SerializeField]
    private Transform atkPoint;
    [SerializeField]
    private float atkRange; 
    [SerializeField]
    private LayerMask layersAtk;

    //Animação
    public Animator anim;
    private int atkCombo = 1;
    private Cooldown nextAtk;
    private Cooldown finishCombo;

    //Detectar se esta atacando ou não.
    private bool ifAttacking;

    void Start() {
        nextAtk = new Cooldown(0.40f, true);
        finishCombo = new Cooldown(0.71f, true);

        this.ifAttacking = false;
     }

    void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.L) && nextAtk.IsFinished )
        {
            Attack();       
            Attacking1();
            Attacking2();
            Attacking3();
        }
        if( finishCombo.IsFinished)
        {
            anim.SetBool("Attacking", false);
            atkCombo = 1;
        }  

    }
    private void Attack()
    {    
        //vai passar a informação se estou atacando ou não para outro script que precisa dessa informação.
        this.ifAttacking = true;

        // Função para alterar os combos em animaçõs de ataque.
        anim.SetBool("Attacking", true); 

        if (atkCombo == 1)
        {
            anim.SetTrigger("Attack1");
            atkCombo++;
        }
        else if ( atkCombo == 2)
        {
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

    public bool playAtk
    {
        get{
            return this.ifAttacking;
        }
    }
    private void Attacking1()
    {   
        //vai passar a informação se estou atacando ou não para outro script que precisa dessa informação.
        this.ifAttacking = true;

        //Função feita para causar o dano.
        Collider2D[] collidersEnemy = Physics2D.OverlapCircleAll( this.atkPoint.position, this.atkRange, this.layersAtk );
        if( collidersEnemy != null)
        {   
            foreach( Collider2D colliderEnemy in collidersEnemy){
            Debug.Log("Atacando objeto" + colliderEnemy.name);
            // Executa a busca de um script no inimigo que esteja no objeto do colider. 
            SlimeTakeDamage enemy = colliderEnemy.GetComponent<SlimeTakeDamage>();

            // Salvamos o valor da busca em Enemy. Se o valor do script for diferente de nulo, ele chama a função takeDamage.
            if (enemy != null)
            {
            enemy.slimeDamage();
            }
            } 
        }
    } 
    private void Attacking2()
    {   
        //vai passar a informação se estou atacando ou não para outro script que precisa dessa informação.
        this.ifAttacking = true;

        //Função feita para causar o dano.
        Collider2D[] collidersEnemy = Physics2D.OverlapCircleAll( this.atkPoint.position, this.atkRange, this.layersAtk );
        if( collidersEnemy != null)
        {   
            foreach( Collider2D colliderEnemy in collidersEnemy){
            Debug.Log("Atacando objeto" + colliderEnemy.name);
            // Executa a busca de um script no inimigo que esteja no objeto do colider. 
            Golem1TakeDamage enemy = colliderEnemy.GetComponent<Golem1TakeDamage>();

            // Salvamos o valor da busca em Enemy. Se o valor do script for diferente de nulo, ele chama a função takeDamage.
            if (enemy != null)
            {
            enemy.golem1Damage();
            }
            } 
        }
    } 
    private void Attacking3()
    {   
        //vai passar a informação se estou atacando ou não para outro script que precisa dessa informação.
        this.ifAttacking = true;

        //Função feita para causar o dano.
        Collider2D[] collidersEnemy = Physics2D.OverlapCircleAll( this.atkPoint.position, this.atkRange, this.layersAtk );
        if( collidersEnemy != null)
        {   
            foreach( Collider2D colliderEnemy in collidersEnemy){
            Debug.Log("Atacando objeto" + colliderEnemy.name);
            // Executa a busca de um script no inimigo que esteja no objeto do colider. 
            Golem2TakeDamage enemy = colliderEnemy.GetComponent<Golem2TakeDamage>();

            // Salvamos o valor da busca em Enemy. Se o valor do script for diferente de nulo, ele chama a função takeDamage.
            if (enemy != null)
            {
            enemy.golem2Damage();
            }
            } 
        }
    } 
    public void finishIfAttacking ()
    {
        this.ifAttacking = false;
    }    
}
