/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/

using UnityEngine;
using System.Collections;

//This class plays a sound upon collision of a rigid body with the floor of a level.

public class CSharp08 : MonoBehaviour {

	void OnCollisionEnter(Collision impact){

		//If the impact is with an object tagged 'Floor', a sound gets triggered
		if(impact.gameObject.CompareTag("Floor"))
			GetComponent<AudioSource>().Play();
		
	}

	void OnTriggerEnter(Collider target){

		//If the object entering the collider is a player
		if(target.CompareTag("Player"))

			// The object's physics are activated
			GetComponent<Rigidbody>().isKinematic = false;
		
	}

}
