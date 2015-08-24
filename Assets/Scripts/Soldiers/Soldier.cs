using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Soldier : MonoBehaviour 
{
    private float speed = 3.0f;
    private bool facingRight;
    private Rigidbody2D rb;
    private Animator anim;
    private Transform player;

    public bool freezeMotion;

    public enum SoldierType {spear, archer}
    private SoldierType SoldierIsType;


	void Start () 
	{
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
        freezeMotion = false;
        checkSoldier();
	}	
	
	void Update () 
	{
        movement();
	}

    void movement()
    {
        if (player == null)
        {
            player = SceneManager.Player;

        }
        else
        {

           

            if (Mathf.Abs(transform.position.x - player.transform.position.x) > 15f)
            {
                freezeMotion = true;
            }
            else if (SoldierIsType == SoldierType.archer)
            {
                if (GetComponent<Archer>().shooting == true)
                {
                    freezeMotion = true;
                    rb.velocity = new Vector2(0f, rb.velocity.y);
                }
                else
                {
                    freezeMotion = false;
                }
            }
            else
            {
                freezeMotion = false;
            }

            float translation = 0f;
            if (!freezeMotion)
            {
                translation = Mathf.Clamp(player.position.x - transform.position.x, -1.0f, 1.0f);
            }
                
            rb.velocity = new Vector2(translation * speed, rb.velocity.y);
        
            anim.SetFloat("Speed", Mathf.Abs(translation));

            if (translation > 0 && !facingRight)
                flip();
            else if (translation < 0 && facingRight)
                flip();
         
        }

    }


    void flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void checkSoldier()
    {
        if (GetComponent<Archer>() != null)
        {
            SoldierIsType = SoldierType.archer;
        }
        else
        {
            SoldierIsType = SoldierType.spear;
        }
    }
}
