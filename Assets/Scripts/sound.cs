using UnityEngine;
using System.Collections;

public class sound : MonoBehaviour
{
    public float soundTimer;
    public AudioSource audio;
	// Use this for initialization
	void Start ()
    {
       soundTimer = 10.0f;
       audio = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        soundTimer -= Time.deltaTime;
        if(soundTimer <= 0)
        {
            audio.Play();
            soundTimer = 10.0f;
        }
	}
}
