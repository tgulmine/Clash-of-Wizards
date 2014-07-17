using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	private bool taNoCampo = true;
	public float hpPlayer = 100;
	private bool cdTeleporte=false;


	// Use this for initialization
	void Start () {
	
	}


	void OnGUI(){
		GUI.Label(new Rect (0,Screen.height - 50,20000,50), "<size=40>HP: "+(int)hpPlayer+"</size>");
	}


	// Update is called once per frame
	void Update () {
		MoverPlayer();
		PerdeVida();
		Rodar ();
		Teleporte();

	}
	
	
	
	void MoverPlayer() {

		Vector2 naoBuga;
		naoBuga = transform.position;
		transform.position = new Vector2(naoBuga.x+speed*Input.GetAxis("Horizontal")*Time.deltaTime, naoBuga.y+Input.GetAxis("Vertical")*speed*Time.deltaTime);
	}

	void Teleporte() {

		Vector3 mousePos;
		Vector3 pos;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		pos = mousePos;

		if (Input.GetKey("q") && cdTeleporte == false) {
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			pos = mousePos;
			transform.position = new Vector2(pos.x, pos.y);
			StartCoroutine("CdTeleporte");
			cdTeleporte = true;
		}
		
	}

	IEnumerator CdTeleporte() {
		yield return new WaitForSeconds(4);
		cdTeleporte = false;
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "BolaFogo") {
			StartCoroutine("EsperaTempo");
		}
	}
	IEnumerator EsperaTempo() {
		yield return new WaitForSeconds(2);
		rigidbody2D.velocity = Vector3.zero;

	}	


	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = false;

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = true;
		
	}

	void PerdeVida() {
		if (taNoCampo == false) {
			hpPlayer -= Time.deltaTime*2;
		}

	}

	void Rodar() {
		Vector3 mousePos;
		Vector3 pos;
		mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mousePos.z = 0;
		pos = mousePos;

		mousePos.x = pos.x-transform.position.x;
		mousePos.y = pos.y-transform.position.y;

		float angle = Mathf.Atan2(mousePos.x, mousePos.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));


		}


}
