using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Archer : MonoBehaviour 
{
    public bool shooting = false;
    private Animator anim;

    private GameObject player;
    private float playerTargetDist;

    private float reloadTime;
    private float shootTime;
    private float shotAniDuration;

    private GameObject arrow;

    public GameObject arrowPrefab;

	void Start () 
	{
        playerTargetDist = 6.0f;
        reloadTime = 2.0f;
        shotAniDuration = 2.0f;
        anim = GetComponentInChildren<Animator>();
        player = GameObject.Find("Player");
	}	
	
	void Update () 
	{
	    
            shoot();
              
	}

    void shoot()
    {
        
            if (shootTime + reloadTime < Time.time && playerTargetDist > (Mathf.Abs(transform.position.x - player.transform.position.x)))
            {
                shooting = true;
                shootTime = Time.time;
                
                arrow =  Instantiate(arrowPrefab, new Vector2(transform.position.x, transform.position.y + 1.2f), Quaternion.identity)as GameObject;
                arrow.GetComponent<Arrow>().startDirection = ((player.transform.position.x - transform.position.x) < 0) ? -1.0f : 1.0f;
            }
            else if (shootTime + shotAniDuration > Time.time)
            {
                shooting = true;
            }
            else
            {
                shooting = false;
            }

            anim.SetBool("Shooting", shooting);
        }    
}
