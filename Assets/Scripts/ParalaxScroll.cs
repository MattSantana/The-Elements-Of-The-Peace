using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScroll : MonoBehaviour
{   
    public float vel = 0.1f;
    public Renderer quad;
    void Start()
    {
        
    }

    void Update()
    {   
        float h = Input.GetAxis("Horizontal") * vel;
        Vector2 offset = new Vector2 (h * Time.deltaTime , 0);
        quad.material.mainTextureOffset += offset;            
    }
}
