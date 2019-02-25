/*

Game Audio  - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015 Modified Sept 2017

*/

using UnityEngine;
using System.Collections;

//This clip will trigger a sound over again while inside a trigger,
//But will randomize its position in a 3D Space each time.

public class CSharp07b : MonoBehaviour {

	//Variables to test 
	public bool stay;

	//This will hold the xyz coordinates of the sound played
	public Vector3 position;

	public AudioClip clip;


	//This function will generate random numbers used for coordinates.
	//It takes the maximum distance as an argument.
	//And returns a float.

	float randomise(float max){

		while(true){

			//two random numbers are generated.
			float value = Random.Range(0f, max);
			float check = Random.Range(0f, max);

			//The greater of the two values is picked, maximizing the odds of the file being played away from the center of the room.
			if(value > check){

				//The random value ios multipled by a number between -1 and 2 to move the sound in either directions at random.
				value *= Random.Range(-1f, 2f);

				return value;

			}

		}

	}


	//This function returns a vector (ie a set of xyz coordinates)

	Vector3 spacialise(){

		// The xyz values of position are randomized by being sent to the randomise function.
		position = new Vector3(
			transform.position.x + randomise(15f), 
			transform.position.y + randomise(10f),
			transform.position.z + randomise(15f));

		return position;

	}

	//Once the tirgger is entered

	void OnTriggerEnter(Collider target){

		//If the object is a player
		if(target.CompareTag("Player")){

			//and for as long as the player is inside
			stay = true;

			//The 'Play' Coroutine gets called
			StartCoroutine("Play");
			
		}
		
	}
	
	void OnTriggerExit(Collider target){
		
		if(target.CompareTag("Player"))
			stay = false;
		
	}

	IEnumerator Play(){
		
		while(stay){

			//As long as the player is inside the trigger
			//an AudioSource is triggered using PlayClipAtPoint

			AudioSource.PlayClipAtPoint(clip, spacialise(), 0.1f);

			//Pause for 5 seconds.
			yield return new WaitForSeconds(5f);
		
		}

	}

}