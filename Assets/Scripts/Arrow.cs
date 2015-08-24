using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Arrow : MonoBehaviour 
{
    private Rigidbody2D rb;

    public float startDirection;


	void Start () 
	{
        transform.Rotate(new Vector3(0.0f, 0.0f, 1f), 40f * -startDirection);
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(8.0f * startDirection, 8.0f);
	    
	}	
	
	void Update () 
	{
	
	}   

    void OnCollisionEnter2D(Collision2D col)
    {
       if (col.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
           
        }

        if (col.gameObject.tag == "PlayerHitBox")
        {
            SceneManager.health--;

            GameObject.Find("AudioManager").GetComponent<AudioManager>().AudSource.PlayOneShot(GameObject.Find("AudioManager").GetComponent<AudioManager>().sounds[0]);

            Destroy(gameObject);
        }
    }
}
