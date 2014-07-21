using UnityEngine;
using System.Collections;

public class AzulAtirar : MonoBehaviour {

	public GameObject tiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	public static bool cdTiroAzul = false;
	public float cdTiroTempoAzul;
	
	public AudioClip fire1;

	void Update () {
		Tiro();
	}

	//Funçao do tiro do mago azul
	void Tiro() {
		if (cdTiroAzul == false) {				
				GameObject tiroClone = (GameObject)Instantiate (tiro, transform.position, Quaternion.identity);
			
				float x, y, z;

				Vector3 dir = AzulScript.alvoAzul.position - AzulScript.azulTransform.position;
				dir.z = 0.0f; //Porque eh 2d

				x = dir.x;
				y = dir.y;
			
				z = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2));
			
				tiroClone.rigidbody2D.AddForce (new Vector2 (x / z * speedTiro, y / z * speedTiro));
				StartCoroutine ("CdTiroAzul");
				cdTiroAzul = true;
		}
	}

	//Tempo de espera para ele atirar novamente
	IEnumerator CdTiroAzul() {
		yield return new WaitForSeconds(cdTiroTempoAzul);
		cdTiroAzul = false;
	}
}
