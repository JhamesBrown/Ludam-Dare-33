using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour 
{
    public AudioClip[] sounds = new AudioClip[3];
    public AudioSource AudSource;

	void Start () 
	{
        AudSource = GetComponent<AudioSource>();
	}	
	
	void Update () 
	{
	
	}
}
