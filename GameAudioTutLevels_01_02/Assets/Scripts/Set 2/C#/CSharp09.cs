/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/

using UnityEngine;
using System.Collections;

// Upon entering the room, 3 cubes have their physics properties turned on, and therefore fall to the ground.
// Unity will detect the velocity of each impact and based on the velocity of the impact different sounds will be triggered.

public class CSharp09 : MonoBehaviour {

	public AudioClip[] sounds;

	//The function ClipNumber returns an int and take two arguments force and limit

	int clipNumber(float force, float limit){

		//the function goes through all the samples loaded in the sounds array
		for(int i = 0; i < sounds.Length; i++){

			// compares the initial impact to the max impact velocity and the number of sounds in the array
			// in this case 3. sample 1 will play for smaller impact velocities.
			if(force < limit  * (i + 1) / sounds.Length)
			   return i;

		}

		return sounds.Length - 1;

	}

	//Upon start of the level sounds are loaded from the resource directory
	void Start(){
		
		sounds = Resources.LoadAll<AudioClip>("Audio/Blocks");
		
	}

	//Called during impact of the cubes
	void OnCollisionEnter(Collision impact){

		// Checks to see if the impact is with the floor
		if(impact.gameObject.CompareTag("Floor")){

			//A clip is assigned to the AudioSource based on the impact magnitude (In relation to velocity)
			//It does so by classing ClipNumber and passing two arguments magnitude of impacts and a ceiling

			GetComponent<AudioSource>().clip = sounds[clipNumber(impact.relativeVelocity.magnitude, 40f)];
			GetComponent<AudioSource>().Play();
			
		}
		
	}

	//Upon entering the trigger the player turns on the physics properties of the objects
	void OnTriggerEnter(Collider target){

		if(target.CompareTag("Player"))
			GetComponent<Rigidbody>().isKinematic = false;

	}

}
