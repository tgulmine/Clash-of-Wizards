using UnityEngine;
using System.Collections;

public class VermelhoAtirar : MonoBehaviour {

	public GameObject tiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	public static bool cdTiroVermelho = false;
	public float cdTiroTempoVermelho;
	
	public AudioClip fire1;

	void Update () {
		Tiro();
		ChecaHpSuperPoder();
	}

	//Funçao do tiro do mago vermelho
	void Tiro() {
		if (cdTiroVermelho == false) {	
				GameObject tiroClone = (GameObject)Instantiate (tiro, transform.position, Quaternion.identity);
			
				float x, y, z;

				Vector3 dir = VermelhoScript.alvoVermelho.position - VermelhoScript.vermelhoTransform.position;
				dir.z = 0.0f; //Porque eh 2d

				x = dir.x;
				y = dir.y;
			
				z = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2));
			
				tiroClone.rigidbody2D.AddForce (new Vector2 (x / z * speedTiro, y / z * speedTiro));
				StartCoroutine ("CdTiroVermelho");
				cdTiroVermelho = true;
		}
	}

	//Tempo de espera para ele atirar novamente
	IEnumerator CdTiroVermelho() {
		yield return new WaitForSeconds(cdTiroTempoVermelho);
		cdTiroVermelho = false;
	}

	//Funçao que checa se o hp dele chegou a 30 ou menos, assim diminuindo drasticamente o tempo de espera de seu tiro, como um super poder
	void ChecaHpSuperPoder() {
		if (VermelhoScript.hpVermelho < 31) cdTiroTempoVermelho = 0.05f;
	}
}
