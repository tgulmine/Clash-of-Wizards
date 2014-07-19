using UnityEngine;
using System.Collections;

public class InimigoScript : MonoBehaviour {

	public static Transform alvo;
	public float moveSpeed;
	public int rotationSpeed;

	public static Transform inimigoTransform;
	
	private bool taNoCampo = true;
	public static float hpInimigo = 100;

	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");		
		alvo = go.transform;
	}
	
	// Update is called once per frame
	void Update () {
		PerdeVida ();
		Rodar();
		MoverAzul();
	}
	
	void Awake() {
		inimigoTransform = transform;
	}

	void PerdeVida() {
		if (taNoCampo == false) {
			hpInimigo -= Time.deltaTime*4;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = false;
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = true;	
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "TiroInimigo") {
			StartCoroutine("EsperaTempo");
		}
		if (col.gameObject.tag == "Tiro") {
			hpInimigo = hpInimigo - 5;
			StartCoroutine("EsperaTempo");
		}
		if (col.gameObject.tag == "SuperTiro") {
			hpInimigo = hpInimigo - 15;
			StartCoroutine("EsperaTempo");
		}
	}

	IEnumerator EsperaTempo() {
		yield return new WaitForSeconds(2);
		rigidbody2D.velocity = Vector3.zero;
	}

	void Rodar() {
		Vector3 dir = alvo.position - inimigoTransform.position;
		dir.z = 0.0f; //Porque eh 2d
		if (dir != Vector3.zero) {
			inimigoTransform.rotation = Quaternion.Slerp (inimigoTransform.rotation,
			                                         Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}
		float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
	}

	void MoverAzul() {
		Vector2 inimigoPosicao = inimigoTransform.position;
		Vector2 dir = alvo.position - inimigoTransform.position;
		transform.position = new Vector2(inimigoPosicao.x+dir.x*moveSpeed*Time.deltaTime, inimigoPosicao.y+dir.y*moveSpeed*Time.deltaTime);
	}
}
