using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject player;
    public float camVel = 0.25f;
    private bool followHero;
    public Vector3 lastTarget;
    public Vector3 atualVel;
    [Range (0, 20)]
    public float AjustCam = 1;
    public Vector3 newCam;

    // Variável para liberar acesso ao código da câmera pelo sprit Knock2.
    public static FollowCamera inst;

    void Awake() 
    {
        if( inst == null)
        {
            inst = this;
        }
    }

    void Start()
    {
        Physics2D.IgnoreLayerCollision(8,3);
        followHero = true;
        lastTarget = player.transform.position;
    }

    void FixedUpdate()
    {
        if(followHero)
        {
            if( player.transform.position.x >= transform.position.x)
            {
                newCam = Vector3.SmoothDamp(transform.position, player.transform.position, ref atualVel, camVel);
                transform.position = new Vector3(newCam.x, newCam.y + AjustCam, transform.position.z);
                lastTarget = player.transform.position;
            }
            else
            {
                newCam = Vector3.SmoothDamp(transform.position, player.transform.position, ref atualVel, camVel);
                transform.position = new Vector3 (transform.position.x, newCam.y + AjustCam, transform.position.z);
            }
        }
    }
    public void CamShake()
    {
        iTween.ShakePosition(gameObject, new Vector3(0.08f, 0,0), 0.3f);
    }
}
