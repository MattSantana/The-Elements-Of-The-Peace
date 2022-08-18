using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inputs : MonoBehaviour
{
    public float vel = 0.2f;
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

    // Verificar se esta atacando para poder andar. 
    [SerializeField]
    private PlayerAtack PlayerAttack;

    //Variável para determinar um tempo de duração do efeito de piscada no Knockback do iTween.
    private WaitForSeconds time = new WaitForSeconds(0.25f);

    //Knockback
    [Header("KnockBack")]
    [SerializeField] private Transform _center;
    [SerializeField] private float _knockbackVel = 8f;
    [SerializeField] private float _knockbackTime = 1f;
    [SerializeField] private bool _knockbacked;
    private SpriteRenderer _spriteRenderer;

    public static Input i ;
    

    void Start()
    {
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
        
        animator = GetComponent<Animator>();
        Knight = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {   
       // Faz o jogador andar
       if( this.PlayerAttack.playAtk )
       {
        transform.Translate (new Vector3(0, 0  ,0));        
       }else{
        // Jogador não esta atacando. Pode se mover!
           float h = Input.GetAxis("Horizontal") ;
           transform.Translate (new Vector3(h * vel, 0  ,0) );  
           
         //Faz o jogador olhar para o lado que ele virar. 
         if( h  > 0 ) 
         { 
           transform.localScale = facingRight;
         }
         if(h < 0 ){
           transform.localScale = facingLeft;
         }                    
       }

        //Faz o Player pular
        inTheGround = Physics2D.OverlapCircle( isGround.position, 0.2f, Ground );

        if( Input.GetButtonDown("Jump") && inTheGround == true )
        {
            Knight.velocity =  Vector2.up * 20;
            //ativar animação do pulo
            animator.SetBool("Jumping", true);
            SlimeIA.canFollow = false;         
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
            SlimeIA.canFollow = true;
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
    }   
   
    public void Knockback(Transform t)
    {
        if(!_knockbacked)
        {
           float h = Input.GetAxis("Horizontal") ;
           transform.Translate (new Vector3(h * vel, 0  ,0) ); 

         //Faz o jogador olhar para o lado que ele virar. 
         if( h  > 0 ) 
         { 
           transform.localScale = facingRight;
         }
         if(h < 0 ){
           transform.localScale = facingLeft;
         }   
        }

        var dir = _center.position - t.position;
        _knockbacked = true;
        Knight.velocity = dir.normalized * _knockbackVel;
        _spriteRenderer.color = Color.red;
        LifeBarEnemy.instance.hitPlayer(1);
        StartCoroutine(FadeToWhite());
        StartCoroutine(Unknockback());
    }
    private IEnumerator FadeToWhite()
    {
        while(_spriteRenderer.color != Color.white)
        {
            yield return null;
            _spriteRenderer.color = Color.Lerp(_spriteRenderer.color, Color.white, Time.deltaTime * 3);

        }
    }

    private IEnumerator Unknockback()
    {
        yield return new WaitForSeconds(_knockbackTime);
        _knockbacked = false;
    } 
}