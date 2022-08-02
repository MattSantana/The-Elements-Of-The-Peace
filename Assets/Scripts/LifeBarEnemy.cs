using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LifeBarEnemy : MonoBehaviour
{
    public int maxLife = 5;
    public int startLife = 3;
    public int startHeart = 4;
    public Image[] containers;
    public Sprite [] spriteHeart;

    public int atualLife;
    public int maxHeart;

    // Variável para liberar acesso ao código da câmera pelo sprit Knock2.
    public static LifeBarEnemy instance = null;

    void Awake() 
    {
        if( instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {        
        calculLifeValue();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            moreHeart();
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            hitPlayer(1);
        }        
    }

    void howMutchLife()
    {   
        heart();

        //Verifico sempre o valor inicial de corações. Para somar ou não.
        for(int i = 0; i < maxLife; i++)
        {
            if( startLife <= i )
            {
                containers[i].enabled = false;
            }
            else{
                containers[i].enabled = true;
            }
        }
    }
    void heart()
    {
        bool empty = false;
        int x = 0;
        
        // Laço criado para percorrer nosso container(Onde estão os corações).
        foreach(Image image in containers)
        {
            if( empty)
            {
                image.sprite = spriteHeart [0];
            }
            else
            {
                x++;
                if( atualLife >= x * startHeart )
                {
                    image.sprite = spriteHeart [4];
                }
                else
                {
                    int atualHeart = (int) (startHeart- ( startHeart * x - atualLife));
                    int lifeImage = startHeart / (spriteHeart.Length - 1);
                    int id = atualHeart / lifeImage;
                    image.sprite = spriteHeart [id];
                    empty = true;
                }
            }
        }
    }
    public void hitPlayer (int d)
    {
        if( atualLife> 0 )
        {
            atualLife -= d;
        }
        heart();
    }
    void moreHeart()
    {
        if( startHeart < maxHeart)
        {
            startHeart++;
        }
        calculLifeValue();
    }
    void calculLifeValue()
    {
        atualLife = startLife * startHeart;
        maxHeart = maxLife * startHeart;

        howMutchLife();
    }

}
