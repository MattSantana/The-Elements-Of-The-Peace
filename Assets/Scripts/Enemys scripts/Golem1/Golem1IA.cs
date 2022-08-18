using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem1IA : MonoBehaviour
{
    private Animator anim;

    private GameObject player;

    public float distance;
    public float distanceControl;
    public float speed = 2f;
    public float visionRange;
    [SerializeField]
    private LayerMask layerTarget;

    private Vector3 facingRight;
    private Vector3 facingLeft;
   



    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;
    }

    void Update()
    {
        FollowThePlayer();

        Collider2D atkPoint = Physics2D.OverlapCircle(this.transform.position, this.visionRange, this.layerTarget);
        if(atkPoint != null)
        {
            anim.SetTrigger("Golem1Attack");
        }

    }

    void FollowThePlayer()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < distanceControl)
        {
            if( player.transform.position.y > transform.position.y)
            {
                transform.position = new Vector2 (transform.position.x, transform.position.y);
                anim.SetBool("Golem1Run", false);
            }else{
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                anim.SetBool("Golem1Run",true);
                Flip();
            }
        }
    }

    private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange); 
  } 

    void Flip()
  {
    if(player.transform.position.x > transform.position.x ){
        transform.localScale = facingRight;
    }
    if(player.transform.position.x < transform.position.x ){
        transform.localScale = facingLeft;
    }  
  }

}
