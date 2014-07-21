using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	private bool taNoCampo = true;
	public static float hpPlayer = 100;
	public static bool cdTeleporte = false;

	public float cdTeleporteTempo;

	private Atirar atirar;
	
	void Update () {
		MoverPlayer ();
		PerdeVida ();
		Rodar ();
		Teleporte ();
		ChecaGameOver ();
	}
	

	//Funçao para mover o jogador com as setas ou WASD
	void MoverPlayer() {
		Vector2 naoBuga;
		naoBuga = transform.position;
		transform.position = new Vector2(naoBuga.x+speed*Input.GetAxis("Horizontal")*Time.deltaTime, naoBuga.y+Input.GetAxis("Vertical")*speed*Time.deltaTime);
	}

	//Funçao da habilidade teleporte, usada com a tecla Q
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

	//Tempo de espera para usar o teleporte novamente
	IEnumerator CdTeleporte() {
		yield return new WaitForSeconds(cdTeleporteTempo);
		cdTeleporte = false;
	}

	//Reconhece se o jogador colidiu com um tiro, e chama o EsperaTempo()
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Tiro" || col.gameObject.tag == "SuperTiro") {
			StartCoroutine("EsperaTempo");
		}
		if (col.gameObject.tag == "TiroInimigo") {
			hpPlayer = hpPlayer - 5;
			StartCoroutine("EsperaTempo");
		}
	}

	//Espera 2 segundos e faz o jogador parar de se mover (para nao andar infinitamente por causa do tiro)
	IEnumerator EsperaTempo() {
		yield return new WaitForSeconds(2);
		rigidbody2D.velocity = Vector3.zero;
	}	

	//Checa se o jogador saiu do campo
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = false;
	}

	//Checa se o jogador entrou no campo
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = true;	
	}

	//Faz o jogador perder vida se estiver fora do campo
	void PerdeVida() {
		if (taNoCampo == false) {
			hpPlayer -= Time.deltaTime*4;
		}
	}

	//Faz o jogador rodar de acordo com a posiçao do mouse
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

	//Checa se o jogador morreu para dar game over
	void ChecaGameOver() {
		if (hpPlayer <= 0) {
			Application.LoadLevel ("gameover"); 
		}
	}
	
}
