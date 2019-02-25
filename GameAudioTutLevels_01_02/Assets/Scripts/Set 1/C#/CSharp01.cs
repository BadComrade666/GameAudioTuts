/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/


//Triggers an audio clip added to an audio source with Play on Awake turned off. 
//This Script is to be added to the object with the audio source.		

using UnityEngine;
using System.Collections;

public class CSharp01 : MonoBehaviour {

	void Start(){
	
		GetComponent<AudioSource> ().pitch = 1.0f;
		GetComponent<AudioSource>().loop = true; //GetComponent<component here> is a very common way to access any type of component from script
		GetComponent<AudioSource>().Play(); // Sends the play message.
	
	}

}