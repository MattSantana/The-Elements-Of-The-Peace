using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knock2 : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rbMain;
    private Vector2 direction;

    public static Knock2 k = null;

  void Awake() 
  {
    if( k == null)
    {
      k = this;
    }   
  }
    void Start()
    {
        rbMain = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col) 
    {
        if( col.gameObject.CompareTag("Enemy"))
        {
            Damage(col);
        }
    }
    public void Damage( Collider2D enemy)
    {
        direction = rbMain.transform.position - enemy.transform.position;
        FollowCamera.inst.CamShake();
        iTween.MoveBy(rbMain.gameObject,iTween.Hash("x", direction.normalized.x * 2.1f, "time", 0.3f));
        iTween.ColorTo(rbMain.gameObject,iTween.Hash("g", 0, "b", 0, "time",0.03f, "looptype", iTween.LoopType.pingPong, "oncompletetarget", rbMain.gameObject,"oncomplete", "stopEffect"));
        LifeBarEnemy.instance.hitPlayer(1);
    }
}
