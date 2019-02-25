/*

Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015

*/

#pragma strict

var triggered : boolean;

function Start(){

	GetComponent.<AudioSource>().loop = true;

}

function OnTriggerEnter(target : Collider){

	if(target.CompareTag("Player")){
		
		if(!triggered)
			GetComponent.<AudioSource>().Play();
		else
			GetComponent.<AudioSource>().UnPause();
			
		GetComponent.<Light>().enabled = true;

	}

}

function OnTriggerExit(target : Collider){
	
	if(target.CompareTag("Player")){
		
		GetComponent.<AudioSource>().Pause();
		GetComponent.<Light>().enabled = false;
		triggered = true;
		
	}
	
}