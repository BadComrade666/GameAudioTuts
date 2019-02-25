/*

Unity3D Audio Examples
Jonathan Califa
March 2015
For Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 

*/

#pragma strict

var sounds : AudioClip[];

function clipNumber(force : float, limit : float){

	for(var i : int= 0; i < sounds.Length; i++){

		if(force < limit  * (i + 1) / sounds.Length)
		   return i;

	}

	return sounds.Length - 1;

}

function Start(){
	
	sounds = Resources.LoadAll.<AudioClip>("Audio/Blocks");
	
}

function OnCollisionEnter(impact : Collision){
	
	if(impact.gameObject.CompareTag("Floor")){

		GetComponent.<AudioSource>().clip = sounds[clipNumber(impact.relativeVelocity.magnitude, 40f)];
		GetComponent.<AudioSource>().Play();
		
	}
	
}

function OnTriggerEnter(target : Collider){

	if(target.CompareTag("Player"))
		GetComponent.<Rigidbody>().isKinematic = false;

}