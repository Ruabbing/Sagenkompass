using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soundmanager : MonoBehaviour 
{
    public static Soundmanager instance;
    private AudioSource audioSource;


    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start () 
	{
		audioSource = GetComponent<AudioSource>();
	}
	
    //play standard sounds in the middle of the scene
	public void PlaySound(AudioClip audio)
	{
		audioSource.PlayOneShot(audio);
	}
}