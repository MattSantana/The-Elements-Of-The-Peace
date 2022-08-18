using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockFallTime : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;
    private float time = 100.0f;
  private void OnCollisionEnter2D(Collision2D other) {
    if( other.gameObject.name.Equals("Knight"))
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.mass = 40f;
        rb.gravityScale = 0.8f;
    }
  }
}
