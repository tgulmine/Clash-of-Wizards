﻿using UnityEngine;
using System.Collections;

public class DestruirTiro : MonoBehaviour {
	
	void Start () {
		//Destroi o tiro depois de 2 segundos
		Destroy (this.gameObject, 2);
	}

	//Se colidir com o inimigo ou um tiro dele, eh destruido
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Inimigo" || col.gameObject.tag == "TiroInimigo" || col.gameObject.tag == "SuperTiro") {
			StartCoroutine("DestroiTiro");
		}
	}

	//Espera para dar tempo dos 2 tiros serem destruidos caso colidam
	IEnumerator DestroiTiro() {
		yield return new WaitForSeconds(0.01f);
		Destroy (this.gameObject);;
	}
}
