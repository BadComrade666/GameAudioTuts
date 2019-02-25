/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/

using UnityEngine;
using System.Collections;

// This script plays a sound at regular intervals while randomizing its pitch, and amplitude, but the files are loaded from a location 
// within the Unity Folder

public class CSharp04 : MonoBehaviour {

	// Public variables for amplitude, pitch and frequency are declared at the top

	public AudioClip[] sounds;
	public int currentClip;
	public float amp = 1f;
	public float pch = 1f;
	public float frq = 5f;

	// a function is declared, with no return type, that will play the sound after randomizing its pitch

	void PlayEveryXSeconds(){

		//Chooses a clip at random from an array
		currentClip = (int)Random.Range(0f, sounds.Length);

		//Assigns that clip to an AudioSource
		GetComponent<AudioSource>().clip = sounds[currentClip];

		//Pitch and Amplitude Randomization
		amp = Random.Range(0.1f, 1f);
		pch = Random.Range(-3f, 3f);
		GetComponent<AudioSource>().volume = amp;
		GetComponent<AudioSource>().pitch = pch;

		//Play the file
		GetComponent<AudioSource>().Play();
		
	}

	//If path refers to a folder, all assets in the folder will be returned. If path refers to a file, 
	//only that asset will be returned. Only objects of type T will be returned. 
	//The path is relative to any Resources folder inside the Assets folder of your project.

	void Start(){

		//Loops the audiosource
		GetComponent<AudioSource>().loop = true;

		//Assigns all the files of type AudioClip in the Resources folder to the sound Array
		sounds = Resources.LoadAll<AudioClip>("");

		//Calls PlayEveryXSeconds at regular intervals
		InvokeRepeating("PlayEveryXSeconds", 0f, frq);

	}

}