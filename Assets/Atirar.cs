using UnityEngine;
using System.Collections;

public class Atirar : MonoBehaviour
{

	public GameObject tiro;
	public GameObject superTiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	public float speedSuperTiro;
	public static bool cdTiro = false;
	public float cdTiroTempo;
	public static bool cdSuperTiro = false;
	public float cdSuperTiroTempo;
	public AudioClip fire1;

	// Update is called once per frame
	void Update () {
		Tiro();
		SuperTiro();
	}

	//Funçao da habilidade tiro, usada com o botao esquerdo do mouse
	void Tiro() {
		if (Input.GetMouseButtonDown(0) && cdTiro == false) {	
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			pos = mousePos;

			GameObject tiroClone = (GameObject) Instantiate(tiro, transform.position, Quaternion.identity);

			float x,y,z;

			x = pos.x-transform.position.x;
			y = pos.y-transform.position.y;

			z = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));

			tiroClone.rigidbody2D.AddForce(new Vector2(x/z*speedTiro, y/z*speedTiro));
			StartCoroutine("CdTiro");
			cdTiro = true;
		}
	}

	//Tempo de espera para atirar novamente
	IEnumerator CdTiro() {
		yield return new WaitForSeconds(cdTiroTempo);
		cdTiro = false;
	}

	//Funçao da habilidade super tiro, usada com a barra de espaço
	void SuperTiro() {
		if (Input.GetKey("space") && cdSuperTiro == false) {	
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			pos = mousePos;
			
			GameObject tiroClone = (GameObject) Instantiate(superTiro, transform.position, Quaternion.identity);
			
			float x,y,z;
			
			x = pos.x-transform.position.x;
			y = pos.y-transform.position.y;
			
			z = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));
			
			tiroClone.rigidbody2D.AddForce(new Vector2(x/z*speedSuperTiro, y/z*speedSuperTiro));
			StartCoroutine("CdSuperTiro");
			cdSuperTiro = true;
		}
	}
	
	//Tempo de espera para usar o super tiro novamente
	IEnumerator CdSuperTiro() {
		yield return new WaitForSeconds(cdSuperTiroTempo);
		cdSuperTiro = false;
	}

}