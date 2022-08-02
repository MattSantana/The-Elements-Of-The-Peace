using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParalaxScroll : MonoBehaviour
{   [SerializeField]
    private float vel = 0.3f;
    public Renderer quad;
    void Start()
    {
        
    }

    void Update()
    {   
        Vector2 offset = new Vector2 (vel * Time.deltaTime , 0);
        quad.material.mainTextureOffset += offset;            
    }
}
