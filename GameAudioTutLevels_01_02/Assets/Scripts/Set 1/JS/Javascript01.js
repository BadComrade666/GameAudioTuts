#pragma strict

function Start(){

	GetComponent.<AudioSource>().loop = true;
	GetComponent.<AudioSource>().Play();

}