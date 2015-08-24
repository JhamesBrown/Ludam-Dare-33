using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Blood : MonoBehaviour 
{
    private Rigidbody2D rb;
    private float r1;
    private float r2;
    private float startTime;

	void Start () 
	{
        startTime = Time.time;
        r1 = Random.Range(-3.0f, 3.0f);
        r2 = Random.Range(-3.0f, 4.0f);
       
        rb = GetComponent<Rigidbody2D>();

        rb.velocity = new Vector2(r1,r2);	
	}	
	
	void Update () 
	{
        if (startTime == 0)
        {
            startTime = Time.time;
        }

        if ((startTime + Mathf.Abs(r1))< Time.time)
        {
            Destroy(gameObject);
        }
	}
}
