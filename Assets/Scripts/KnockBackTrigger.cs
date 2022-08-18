using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnockBackTrigger : MonoBehaviour
{
[SerializeField]
private float knock;
[SerializeField]
private LayerMask layerTarget;

/* public void OnCollisionEnter2D(Collision2D other) {
    var player = other.collider.GetComponent<Inputs>();
    if(player != null)
    {
        player.Knockback(transform);
    }
} */
public void Trigger()
{
    Collider2D player = Physics2D.OverlapCircle(this.transform.position, this.knock, this.layerTarget);

    if(player != null)
    {
        var Knight = player.GetComponent<Inputs>();
        Knight.Knockback(transform);
    }
}
}
