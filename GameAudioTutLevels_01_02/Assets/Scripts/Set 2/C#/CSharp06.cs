/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2015

*/


using UnityEngine;
using System.Collections;

// This script plays a sound and triggers a sound and light as long as the players remains inside a trigger

public class CSharp06 : MonoBehaviour {

	public bool triggered;

	//The AudioSource gets looped right away

	void Start(){
		
		GetComponent<AudioSource>().loop = true;
		
	}
	
	//Upon an object entring the trigger...

	void OnTriggerEnter(Collider target){

		//Unity checks to see whether the object is a player (or an object tagged player anyhow")

		if(target.CompareTag("Player")){

			//If the triggered variable has not been set to true the sound will start

			if(!triggered)
				GetComponent<AudioSource>().Play();

			//Otherwise the AudioSource gets unpaused.
			else
				GetComponent<AudioSource>().UnPause();

			// And the lights turned on.
			GetComponent<Light>().enabled = true;

		}

	}

	//Upon leaving the collider...

	void OnTriggerExit(Collider target){

		//If the object is a player...
		if(target.CompareTag("Player")){

			//The AudioSource is Paused
			GetComponent<AudioSource>().Pause();

			//The light turned on
			GetComponent<Light>().enabled = false;

			//And the variable triggered is set to true.
			triggered = true;
			
		}
		
	}

}
