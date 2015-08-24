using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour 
{
    public static int health;

    public static Transform Player;

    public Texture2D hpGreen;
    public Texture2D hpRed;

    public GUIStyle HpFullStyle;
    public GUIStyle HpEmptyStyle;


	void Start () 
	{
       
	}	


	
	void Update () 
	{
        if (Player == null)
        {
            Player = GameObject.Find("Player").transform;

        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel(Application.loadedLevel);
        }

        Camera.main.transform.position = new Vector3(Player.transform.position.x,Player.transform.position.y,-10f);
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
    void OnGUI()
    {
        GUI.BeginGroup(new Rect((Screen.width/2) - 100f,20f,200f,30f),hpRed,HpEmptyStyle);
        GUI.Label(new Rect(0f, 0f, 20f *  health,30f ), hpGreen,HpFullStyle);
        GUI.EndGroup();


    }
}
