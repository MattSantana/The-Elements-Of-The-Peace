using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    public float vel = 0.1f;
    void Start()
    {
    }

    void Update()
    {
       float h =  Input.GetAxis("Horizontal");
   
       transform.Translate(new Vector3(h * Time.deltaTime, 0 , 0) * vel) ;        
    }
}
