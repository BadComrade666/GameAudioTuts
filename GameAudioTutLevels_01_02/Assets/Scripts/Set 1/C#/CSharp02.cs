/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2015

*/


using UnityEngine;
using System.Collections;

public class CSharp02 : MonoBehaviour {

	//[SerializeField]
	AudioSource jojo;
		

	//[SerializeField]
	float vol, pch;

	[SerializeField]
	float volMin, volMax, pchMin, pchMax;

	void Start(){
	
		jojo = GetComponent<AudioSource> ();
		jojo.loop = true;

		vol = Random.Range (volMin, volMax);
		pch = Random.Range (pchMin, pchMax );

		jojo.volume = vol;
		jojo.pitch = pch;

		jojo.Play();
	
	}

}


