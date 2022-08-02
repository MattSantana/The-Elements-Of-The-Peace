using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    //Variáveis pra movimentar o vilão até o jogador e animação.
 
    #region
    //variáveis da patrulha, fazer ele andar.
    private float moveSpeed = 2;
    private Rigidbody2D rb;
    private bool moveE;
    [SerializeField]
    private Transform[] limit;
    #endregion


    public LayerMask layerV;
    private Animator anim;
  

    #region//Variáveis pra definir alcance de ataque
    [SerializeField]
    private bool visionE;
    [SerializeField]
    private float visionRange;
    [SerializeField]
    private SpriteRenderer srender;
    [SerializeField]
    private LayerMask layerTarget;
    private bool call = true;
    private WaitForSeconds time = new WaitForSeconds(1);
    #endregion
    
    [SerializeField]
    private bool atkPoint = true;

    // Variáveis para acessar efeito de KnockBack
    public Knock2 k;
    //Variável para estabelecer tempo do efeito
    private WaitForSeconds t = new WaitForSeconds(1);

void Start() {
  Physics2D.IgnoreLayerCollision(3,3);
  Physics2D.IgnoreLayerCollision(0,3);

  rb = GetComponent<Rigidbody2D>();
  srender = GetComponent<SpriteRenderer>();
  anim = GetComponent<Animator> ();
  moveE = true;
}
IEnumerator followKnight( bool flipx, bool movE)
{
  yield return t;
  srender.flipX= flipx;
  moveE = movE;
}
void Update()
  { 
    visionE = Physics2D.OverlapCircle(transform.position, visionRange, layerTarget);

    if( visionE)
    {
      var relativeP = transform.InverseTransformPoint( Physics2D.OverlapCircle(transform.position, visionRange, layerTarget).gameObject.transform.position );

      if( relativeP.x < 0.0)
      {
        StartCoroutine(followKnight(false,true));

      }else if( relativeP.x > 0.0f )
      {
        StartCoroutine(followKnight(true,false));
      }
    }
   
    atkPoint = Physics2D.OverlapCircle(transform.position, visionRange * 0.3f, layerTarget);
    
    if(!atkPoint)
    {
      anim.SetBool("SlimeRun", true);
      if(moveE)
      {
        rb.velocity = new Vector2(- moveSpeed, rb.velocity.y);
      }
      else
      {
        rb.velocity = new Vector2( moveSpeed, rb.velocity.y);
      }
    }
    else{
      anim.SetBool("SlimeRun", false);
      anim.SetTrigger("SlimeAttack");
      if(k == null)
      {
        k= Physics2D.OverlapCircle(transform.position, visionRange * 0.2f, layerTarget).GetComponent<Knock2>();
      }
      k.Damage (Physics2D.OverlapCircle(transform.position, visionRange * 0.2f, layerTarget).GetComponent<Collider2D>());
    }
    verfifyCol();

  }
  void verfifyCol()
  {
    if(!Physics2D.Raycast(limit[0].position, Vector2.down, 0.1f) && call || !Physics2D.Raycast(limit[1].position, Vector2.down, 0.1f) && call )
    { 
      StartCoroutine(callFlip());
    }
  }
  IEnumerator callFlip()
  {
    Flip();
    call = false;
    yield return time;
    call = true;
  }
  void Flip()
  {
    moveE = !moveE;

    if(moveE)
    {
      srender.flipX = true;
    }
    else
    {
      srender.flipX = false;
    }
    
  }

  private void OnDrawGizmos() {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange );
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange*0.3f);
  }
}
