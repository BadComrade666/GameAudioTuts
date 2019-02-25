/*

Unity3D Audio Examples
Jonathan Califa
March 2015
For Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 

*/

#pragma strict

var triggered : boolean;

function OnTriggerEnter(target : Collider){
	
	if(!triggered){

		if(target.CompareTag("Player")){
			
			GetComponent.<AudioSource>().Play();
			GetComponent.<Light>().enabled = true;
			
		}

	}
	
}
	
function OnTriggerExit(target : Collider){
	
	if(!triggered){
		
		if(target.CompareTag("Player")){
			
			GetComponent.<AudioSource>().Stop();
			GetComponent.<Light>().enabled = false;
			triggered = true;
			
		}
		
	}
	
}