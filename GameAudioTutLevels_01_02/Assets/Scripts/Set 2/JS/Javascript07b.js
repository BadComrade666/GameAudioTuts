/*

Unity3D Audio Examples
Jonathan Califa
March 2015
For Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 

*/

#pragma strict

var stay : boolean;
var position : Vector3;
var clip : AudioClip;

function randomise(max : float){

	while(true){

		var value : float = Random.Range(0f, max);
		var check : float = Random.Range(0f, max);
		
		if(value > check){

			value *= Random.Range(-1f, 2f);
			
			return value;

		}

	}
	
	return 0f;

};

function spacialise(){

	position = new Vector3(
		transform.position.x + new randomise(15f), 
		transform.position.y + new randomise(10f),
		transform.position.z + new randomise(15f));

	return position;

};

function OnTriggerEnter(target : Collider){
	
	if(target.CompareTag("Player")){

		stay = true;
		InvokeRepeating("Play", 0f, 5f);
		
	}
	
}

function OnTriggerExit(target : Collider){
	
	if(target.CompareTag("Player"))
		stay = false;
	
}

function Play(){
	
	if(stay)
		AudioSource.PlayClipAtPoint(clip, spacialise(), 0.1f);

}