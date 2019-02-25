/*

Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 
Unity3D Audio Examples
Jonathan Califa
March 2015

*/

#pragma strict

var amp : float = 1f;
var pch : float = 1f;
var frq : float = 5f;

InvokeRepeating("PlayEveryXSeconds", 0f, frq);

function Start(){

	GetComponent.<AudioSource>().loop = true;

}

function PlayEveryXSeconds(){

	amp = Random.Range(0.1f, 1f);
	pch = Random.Range(-3f, 3f);
	GetComponent.<AudioSource>().volume = amp;
	GetComponent.<AudioSource>().pitch = pch;
	GetComponent.<AudioSource>().Play();

}