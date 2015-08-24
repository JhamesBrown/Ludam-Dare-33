using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HurtBox : MonoBehaviour 
{
	
	void Start () 
	{
	
	}	
	
	void Update () 
	{
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {   

        if (col.gameObject.tag == "PlayerHitBox")
        {
            SceneManager.health--;
            GameObject.Find("AudioManager").GetComponent<AudioManager>().AudSource.PlayOneShot(GameObject.Find("AudioManager").GetComponent<AudioManager>().sounds[0]);

            Destroy(gameObject);
        }
    }
}
