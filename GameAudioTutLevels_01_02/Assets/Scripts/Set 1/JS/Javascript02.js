/*

Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015

*/

#pragma strict

function Start(){

	GetComponent.<AudioSource>().pitch = 0.5f;
	GetComponent.<AudioSource>().loop = true;
	GetComponent.<AudioSource>().Play();

}