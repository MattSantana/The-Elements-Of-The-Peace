using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float vel = 0.2f;

    // Verificar se esta atacando para poder mover a câmera. 
    [SerializeField]
    private PlayerAtack PlayerAttack;
    
    void Start()
    {
    }

    void Update()
    {
       if( this.PlayerAttack.playAtk )
       {
        // ISSO DA BUGANDO O PARLLAX. Tenho que criar uma função que impeça o parallax de se mover quando o player não anda.
        transform.Translate (new Vector3(0, 0  ,0));        
       }else{
        // Jogador não esta atacando. Pode se mover!
        float h = Input.GetAxis("Horizontal") ;
        transform.Translate (new Vector3(h * vel, 0  ,0) );   
       }
    }
}