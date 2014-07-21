using UnityEngine;
using System.Collections;

public class DestruirTiroInimigo : MonoBehaviour {
	
	void Start () {
		//Destroi o tiro depois de 2 segundos
		Destroy (this.gameObject, 2);
	}

	//Se colidir com o jogador ou com um tiro dele, eh destruido
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player" || col.gameObject.tag == "Tiro" || col.gameObject.tag == "SuperTiro") {
			StartCoroutine("DestroiTiro");
		}
	}

	//Espera para dar tempo dos 2 tiros serem destruidos caso colidam 
	IEnumerator DestroiTiro() {
		yield return new WaitForSeconds(0.01f);
		Destroy (this.gameObject);;
	}
}
