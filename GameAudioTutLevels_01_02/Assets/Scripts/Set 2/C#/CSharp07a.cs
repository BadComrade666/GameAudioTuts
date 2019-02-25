/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/

using UnityEngine;
using System.Collections;

// This script plays a sound and triggers a sound and light as long as the players remains inside a trigger
// However, once it has been triggered once, the sound and light will not be triggered again.

public class CSharp07a : MonoBehaviour {
	
	public bool triggered;

	void OnTriggerEnter(Collider target){

		//If the triggered variable hasn't been set to true yet
		if(!triggered){

			//and if the object entering the trigger is a player (Tagged as such anyway)
			if(target.CompareTag("Player")){

				//The AudioSource will play and the light be turned on.
				GetComponent<AudioSource>().Play();
				GetComponent<Light>().enabled = true;
				
			}

		}
		
	}
		
	//Upon leaving the trigger
	void OnTriggerExit(Collider target){

		//if trigger is set to false
		if(!triggered){

			//And the object is a player
			if(target.CompareTag("Player")){

				//Stop the audio and turn off the lights
				GetComponent<AudioSource>().Stop();
				GetComponent<Light>().enabled = false;

				//set triggered to true.
				triggered = true;

				//Since triggered doesn't get reset to false, the sound and light will not be triigered again.
			}
			
		}
		
	}
}
