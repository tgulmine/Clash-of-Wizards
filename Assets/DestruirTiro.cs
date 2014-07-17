using UnityEngine;
using System.Collections;

public class DestruirTiro : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			Destroy(this.gameObject);
		}
	}

	void Start() {
		Destroy(this.gameObject, 2);
	}


}