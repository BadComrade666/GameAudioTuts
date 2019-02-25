/*

Unity3D Audio Examples
Jonathan Califa
March 2015
For Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 

*/

#pragma strict

function OnCollisionEnter(impact : Collision){
	
	if(impact.gameObject.CompareTag("Floor"))
		GetComponent.<AudioSource>().Play();
	
}

function OnTriggerEnter(target : Collider){
	
	if(target.CompareTag("Player"))
		GetComponent.<Rigidbody>().isKinematic = false;
	
}