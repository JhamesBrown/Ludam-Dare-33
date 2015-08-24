using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FreedomScreen : MonoBehaviour 
{
	
	void Start () 
	{
	
	}	
	
	void Update () 
	{

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(1);
        }

        

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

	}


}
