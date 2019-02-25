/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2015

*/

using UnityEngine;
using System.Collections;

// This script plays a sound at regular intervals while randomizing its pitch, and amplitude

public class CSharp03 : MonoBehaviour {

	// Public variables for amplitude, pitch and frequency are declared at the top



	[SerializeField]
	 float amp = 1f;
	[SerializeField]
	 float pch = 1f;
	[SerializeField]
	 float frq = 5f;


	// a function is declared, with no return type, that will play the sound after randomizing its pitch

	void PlayEveryXSeconds(){

		amp = Random.Range (0.1f, 1f); 
		pch = Random.Range (0.1f, 3f);
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().pitch = pch;
		GetComponent<AudioSource>().Play();
	
	}

	// Called at Start (there for prior to the PlayEveryXSeconds functions) InvokeRepeating will trigger a function starting at a time specified as a 2nd argument
	// and at the interval specified by its 3rd argument

	void Start(){


		InvokeRepeating("PlayEveryXSeconds", 0f, frq);
		
	}

}