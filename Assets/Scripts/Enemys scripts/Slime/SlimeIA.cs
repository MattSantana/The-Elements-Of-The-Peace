using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeIA : MonoBehaviour
{
    private Animator anim;
    public static bool canFollow;
    public static bool canFlip;

    private GameObject player;

    public float distance;
    public float distanceControl;
    public float speed = 2f;
    public float visionRange;
    [SerializeField]
    private LayerMask layerTarget;

    public static SlimeIA inst;

    public SpriteRenderer faceFlip;


    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        anim = GetComponent<Animator>();
        faceFlip = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Collider2D atkPoint = Physics2D.OverlapCircle(this.transform.position, this.visionRange, this.layerTarget);
        if(atkPoint != null)
        {
            anim.SetTrigger("SlimeAttack");
        }

    }

    public void FollowThePlayer()
    {
        distance = Vector2.Distance(player.transform.position, transform.position);

        if (distance < distanceControl && canFollow)
        {
            canFlip= true;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            anim.SetBool("SlimeRun",true);
            Flip();
        }
    }

    private void OnDrawGizmos() {
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere( this.transform.position, this.visionRange); 
  } 
    void Flip()
  {
    if(player.transform.position.x < transform.position.x){
        faceFlip.flipX = true;
    }
    if(player.transform.position.x > transform.position.x){
        faceFlip.flipX = false;
    }  
  }

}
