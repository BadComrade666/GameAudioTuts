/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2015

*/

//This script will trigger one of several sounds, wait for this sound to be over
//Then trigger a second one. This is useful for impact and debris sounds for instance.

using UnityEngine;
using System.Collections;

public class CSharp10 : MonoBehaviour {

	// two arrays are declared
	public AudioClip[] explosions;
	public AudioClip[] debris;
	
	public float amp = 1f;
	public float pch = 1f;



	void Start(){

		// both arrays are filled using audio files located in the resources folder
		explosions = Resources.LoadAll<AudioClip>("Audio/Explosions");
		debris = Resources.LoadAll<AudioClip>("Audio/Debris");
		
	}

	//The player enters the trigger
	void OnTriggerEnter(){

		//the function expolosion is invoked
		Invoke("Explosion", 0f);
		
	}

	void Explosion(){

		//and audio clip is picked at random
		AudioClip thisOne = explosions[(int)Random.Range(0f, explosions.Length)];

		//Assigned to the source
		GetComponent<AudioSource>().clip = thisOne;

		//randomized and played
		amp = Random.Range(0.1f, 1f);
//		
		pch = 1f;
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().pitch = pch;
		GetComponent<AudioSource>().Play();

		//Invoke debris is triggered after the prior file is done playing
		Invoke("Debris", thisOne.length / pch);

	}

	void Debris(){

		AudioClip thisOne = debris[(int)Random.Range(0f, debris.Length)];
		
		GetComponent<AudioSource>().clip = thisOne;
		
		amp = Random.Range(0.1f, 1f);
		pch = 1f;
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().pitch = pch;
		GetComponent<AudioSource>().Play();

	}
	
}
