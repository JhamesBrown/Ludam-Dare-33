using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OpeningSequenceManager : MonoBehaviour 
{
    private float startTime;
    private float fadeInDuration = 2.0f;
    private float fadeinDelay = 5.0f;

    public SpriteRenderer anyKeyText;

	void Start () 
	{
        startTime = Time.time;
        anyKeyText = GetComponentInChildren<SpriteRenderer>();
	}	
	
	void Update () 
	{
        if (startTime + fadeinDelay < Time.time)
        {
            float alpha = Mathf.Lerp(0.0f, 0.9f, ( (Time.time - fadeinDelay)/ fadeInDuration));
            anyKeyText.color = new Color(1.0f, 1.0f, 1.0f, alpha);

            if (Input.anyKeyDown)
            {
                Application.LoadLevel(1);
            }
        }
	

        if (Input.GetKeyDown(KeyCode.Escape))
	    {
            Application.Quit();
	    }
	}

}
