using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    private float vel = 1.0f;
    private Rigidbody2D Knight;

    public Animator animator;

    public int doubleJump = 1;
    public bool inTheGround;
    
    // Vai detectar se estamos no chão ou não.
    public Transform isGround;
    // Identifica o que é chão.
    public LayerMask Ground;

    //Virar pro lado que eu andar
    private float direction;
    private Vector3 facingRight;
    private Vector3 facingLeft;


    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        
        animator = GetComponent<Animator>();
        Knight = GetComponent<Rigidbody2D>();
    }

    void Update()
    {   
        // Faz o jogador andar
        float h = Input.GetAxis("Horizontal") ;
        transform.Translate (new Vector3(h * Time.deltaTime, 0  ,0) * vel);
        
        //Faz o jogador olhar para o lado que ele virar. 
        if( h  > 0 ) 
        { 
           transform.localScale = facingRight;
        }
        if(h < 0 ){
           transform.localScale = facingLeft;
        }

        //Make the player jump
        inTheGround = Physics2D.OverlapCircle( isGround.position, 0.2f, Ground );

        if( Input.GetButtonDown("Jump") && inTheGround == true )
        {
            Knight.velocity =  Vector2.up * 20;
            //ativar animação do pulo
            animator.SetBool("Jumping", true);         
        }
        
        if( Input.GetButtonDown("Jump") && inTheGround == false && doubleJump > 0 )
        {
            Knight.velocity =  Vector2.up * 15;
            doubleJump--;
           
        }
        if( inTheGround && Knight.velocity.y == 0)
        {
            doubleJump = 1;
            animator.SetBool("Jumping", false);
        }

            //Muda a animação do player.
        if(Input.GetAxis("Horizontal") != 0)
        {
            // sendo pra trás ou pra frente, o valor vai ser negativo ou positivo, ou seja. Diferente de 0. Então ele vai puxar a animação de andar.
            animator.SetBool("Walking", true);
        } else{
            //o player vai ficar parado, porque o movimento em horinzontal é = a 0.
            animator.SetBool("Walking", false);

        }  
        //Muda para a animação de ataque
/*         if(Input.GetAxis("Fire1") != 0)
        {
            animator.SetBool("Attacking", true);           
        }else{
            animator.SetBool("Attacking", false);           
        } */
    }   
}