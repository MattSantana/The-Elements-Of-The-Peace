using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimePatrol : MonoBehaviour
{
    //Variáveis pra movimentar o vilão até o jogador e animação.
 
    #region
    //variáveis da patrulha, fazer ele andar.
    private float moveSpeed = 2f;
    private Rigidbody2D rb;
    [SerializeField]
    private Transform pontoA; 
    [SerializeField]
    private Transform pontoB;
    private bool move;
    #endregion

    private Animator anim;
  

    [SerializeField]
    private float visionRange;
    [SerializeField]
    private LayerMask layerTarget;


  public SpriteRenderer faceFlip;



    

void Start() {
  Physics2D.IgnoreLayerCollision(3,3);
  Physics2D.IgnoreLayerCollision(0,3);

  rb = GetComponent<Rigidbody2D>();
  anim = GetComponent<Animator> ();
  faceFlip = GetComponent<SpriteRenderer>();


}

void Update()
  { 
    playerOnRange();
    anim.SetBool("SlimeRun", true);
    Flip();
  }

  void playerOnRange (){
    Collider2D player = Physics2D.OverlapCircle(this.transform.position, this.visionRange, this.layerTarget);

    if(player == true)
    {
      var target = GetComponent<SlimeIA>();
      target.FollowThePlayer();
    }else{
      Patrol();
    }
  }
  private void Patrol()
  {    
    if(transform.position.x < pontoA.position.x)
    {
      move= true;
    }
    if(transform.position.x > pontoB.position.x)
    {
    move= false;
   }       

    if(move == true)
    {
      transform.position= new Vector2 ( transform.position.x + Time.deltaTime * moveSpeed, transform.position.y);
    }else
    {
      transform.position= new Vector2 ( transform.position.x - Time.deltaTime * moveSpeed, transform.position.y);
    }

  }

   private void OnDrawGizmos() {
    Gizmos.color = Color.green;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange );
/*     Gizmos.color = Color.red;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange*0.3f); */
  } 
  void Flip()
  {
    if(transform.position.x < pontoA.position.x && SlimeIA.canFlip == false){
      faceFlip.flipX = false;
    }
    if(transform.position.x > pontoB.position.x && SlimeIA.canFlip == false){
        faceFlip.flipX = true;
    }  
  }
}
