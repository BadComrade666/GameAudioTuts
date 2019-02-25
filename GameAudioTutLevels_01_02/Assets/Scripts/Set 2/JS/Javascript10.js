/*

Unity3D Audio Examples
Jonathan Califa
March 2015
For Game Audio 1 - Jean-Luc Sinclair Professor.
New York University - Steinhardt School of Culture, Education and Human Development. 

*/

#pragma strict

var explosions : AudioClip[];
var debris : AudioClip[];
var amp : float = 1f;
var pch : float = 1f;

function scale(stray : float){
	
	while(true){
		
		var value : float = Random.Range(0f, stray);
		var check : float = Random.Range(0f, stray);
		var positive : boolean = false;
		
		if(value < check){

			if(Random.value < 0.5f)
				positive = !positive;

			value += 1f;
			value = positive ? value : 1f / value;

			return value;
			
		}
		
	}
	
	return 1f;
	
}

function Start(){

	explosions = Resources.LoadAll.<AudioClip>("Audio/Explosions");
	debris = Resources.LoadAll.<AudioClip>("Audio/Debris");
	
}

function OnTriggerEnter(){
	
	Invoke("Explosion", 0f);
	
}

function Explosion(){

	var clip : int = Random.Range(0f, explosions.Length);
	var thisOne : AudioClip = explosions[clip];

	GetComponent.<AudioSource>().clip = thisOne;
	
	amp = Random.Range(0.1f, 1f);
	pch = scale(1f);
	GetComponent.<AudioSource>().volume = amp;
	GetComponent.<AudioSource>().pitch = pch;
	GetComponent.<AudioSource>().Play();

	Invoke("Debris", thisOne.length / pch);

}

function Debris(){

	var clip : int = Random.Range(0f, debris.Length);
	var thisOne : AudioClip = debris[clip];
	
	GetComponent.<AudioSource>().clip = thisOne;
	
	amp = Random.Range(0.1f, 1f);
	pch = scale(1f);
	GetComponent.<AudioSource>().volume = amp;
	GetComponent.<AudioSource>().pitch = pch;
	GetComponent.<AudioSource>().Play();

}