/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2015

*/


using UnityEngine;
using System.Collections;

// This script plays a sound at regular intervals while randomizing its pitch, and amplitude, but the files are loaded from a location 
// within the Unity Folder. No file chosen at random from the resource folder will be played twice in a rwo however.


public class CSharp05 : MonoBehaviour {

	// Public variables for amplitude, pitch and frequency are declared at the top
	// A new variable is introduced: previousClip. It will allow us to keep track of the last clip played.

	public AudioClip[] sounds;
	public int currentClip;
	public int previousClip;
	public float amp = 1f;
	public float pch = 1f;
	public float frq = 5f;

	// a function is declared, with no return type, that will play the sound after randomizing its pitch
	
	void PlayEveryXSeconds(){

		//This code will keep picking a different file until the current and previous clips are no longer the same.
		//The While loop first compares the current and previous clip, and also makes sure the array isn't empty.

		while (currentClip == previousClip && sounds.Length != 0) {
			currentClip = (int)Random.Range (0f, sounds.Length);
		}

		// Once the condition has been met (current and previous clips are not the same) the clip gets assigned to a component
		GetComponent<AudioSource>().clip = sounds[currentClip];

		//Its pitch and amplitude randomized
		amp = Random.Range(0.1f, 1f);
		pch = Random.Range(-3f, 3f);
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().pitch = pch;

		//The clip gets triggered
		GetComponent<AudioSource>().Play();

		//The current clip number is assigned to the previous clip variable
		previousClip = currentClip;
		
	}


	//If path refers to a folder, all assets in the folder will be returned. If path refers to a file, 
	//only that asset will be returned. Only objects of type T will be returned. 
	//The path is relative to any Resources folder inside the Assets folder of your project.
	
	void Start(){

		// //Loops the audiosource
		GetComponent<AudioSource>().loop = true;

		//Assigns all the files of type AudioClip in the Resources folder to the sound Array
		sounds = Resources.LoadAll<AudioClip>("");

		//Calls PlayEveryXSeconds at regular intervals
		InvokeRepeating("PlayEveryXSeconds", 0f, frq);
		
	}
	
}