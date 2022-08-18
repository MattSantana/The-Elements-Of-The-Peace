using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalPlataformMove : MonoBehaviour
{
    private bool move;
    private float vel = 2f;
    [SerializeField]
    private Transform pontoA; 
    [SerializeField]
    private Transform pontoB;

    void Start() {
      Physics2D.IgnoreLayerCollision(8,6);
    }

    void Update()
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
            transform.position= new Vector2 ( transform.position.x + Time.deltaTime * vel, transform.position.y);
        }else
        {
            transform.position= new Vector2 ( transform.position.x - Time.deltaTime * vel, transform.position.y);
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        other.collider.transform.SetParent(transform);
    }
    private void OnCollisionExit2D(Collision2D other) {
        other.collider.transform.SetParent(null);
    }
}
