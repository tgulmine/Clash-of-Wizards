﻿using UnityEngine;
using System.Collections;

public class VerdeAtirar : MonoBehaviour {

	public GameObject tiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	public static bool cdTiroVerde = false;
	public float cdTiroTempoVerde;
	
	public AudioClip fire1;

	void Update () {
		Tiro();
	}

	//Funçao do tiro do mago verde
	void Tiro() {
		if (cdTiroVerde == false) {	
				GameObject tiroClone = (GameObject)Instantiate (tiro, transform.position, Quaternion.identity);
			
				float x, y, z;

			Vector3 dir = VerdeScript.alvoVerde.position - VerdeScript.verdeTransform.position;
				dir.z = 0.0f; //Porque eh 2d

				x = dir.x;
				y = dir.y;
			
				z = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2));
			
				tiroClone.rigidbody2D.AddForce (new Vector2 (x / z * speedTiro, y / z * speedTiro));
				StartCoroutine ("CdTiroVerde");
				cdTiroVerde = true;
		}
	}

	//Tempo de espera para ele atirar novamente
	IEnumerator CdTiroVerde() {
		yield return new WaitForSeconds(cdTiroTempoVerde);
		cdTiroVerde = false;
	}
}
