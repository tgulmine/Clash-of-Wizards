using UnityEngine;
using System.Collections;

public class InimigoAtirar : MonoBehaviour {

	public GameObject tiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	public static bool cdTiroInimigo = false;
	public float cdTiroTempoInimigo;
	
	public AudioClip fire1;
	
	// Update is called once per frame
	void Update () {
		Tiro();
	}

	void Tiro() {
		if (cdTiroInimigo == false) {	
				//mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//mousePos.z = 0;
				//pos = mousePos;
				//gameObject.collider2D.enabled = false;
			
				GameObject tiroClone = (GameObject)Instantiate (tiro, transform.position, Quaternion.identity);
			
				float x, y, z;

				Vector3 dir = InimigoScript.alvo.position - InimigoScript.inimigoTransform.position;
				dir.z = 0.0f; //Porque eh 2d
			
				//x = pos.x - transform.position.x;
				//y = pos.y - transform.position.y;
				x = dir.x;
				y = dir.y;
			
				z = Mathf.Sqrt (Mathf.Pow (x, 2) + Mathf.Pow (y, 2));
			
				tiroClone.rigidbody2D.AddForce (new Vector2 (x / z * speedTiro, y / z * speedTiro));
				StartCoroutine ("CdTiroInimigo");
				cdTiroInimigo = true;
		}
	}

	//Tempo de espera para atirar novamente
	IEnumerator CdTiroInimigo() {
		yield return new WaitForSeconds(cdTiroTempoInimigo);
		cdTiroInimigo = false;
	}
}
