using UnityEngine;
using System.Collections;

public class VermelhoScript : MonoBehaviour {

	public static Transform alvoVermelho;
	public float moveSpeed;
	public int rotationSpeed;

	public static Transform vermelhoTransform;
	
	private bool taNoCampo = true;
	public static float hpVermelho = 100;
	
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag("Player");		
		alvoVermelho = go.transform;
	}

	void Update () {
		PerdeVida ();
		Rodar();
		ChecaMover();
		ChecaVida ();
	}
	
	void Awake() {
		vermelhoTransform = transform;
	}

	//Checa se o jogador esta no campo, para nao segui-lo quando ele estiver na lava, chamando a funcao Mover()
	void ChecaMover() {
		if (PlayerScript.taNoCampo == true) Mover();
	}

	//Funcao que faz ele perder vida com o tempo quando esta na lava
	void PerdeVida() {
		if (taNoCampo == false) {
			hpVermelho -= Time.deltaTime*4;
		}
	}

	//Checa se ele saiu do campo
	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = false;
	}

	//Checa se ele entrou no campo
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Campo")
			taNoCampo = true;	
	}

	//Checa se colidiu e toma acoes baseado nisso, depois chama o EsperaTempo()
	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "TiroInimigo") {
			StartCoroutine("EsperaTempo");
		}
		if (col.gameObject.tag == "Tiro") {
			hpVermelho = hpVermelho - 5;
			StartCoroutine("EsperaTempo");
		}
		if (col.gameObject.tag == "SuperTiro") {
			hpVermelho = hpVermelho - 15;
			StartCoroutine("EsperaTempo");
		}
	}

	//Espera um tempo para voltar a se mover normalmente, depois de ter uma colisao
	IEnumerator EsperaTempo() {
		yield return new WaitForSeconds(2);
		rigidbody2D.velocity = Vector3.zero;
	}

	//Funcao que permite ele rodar
	void Rodar() {
		Vector3 dir = alvoVermelho.position - vermelhoTransform.position;
		dir.z = 0.0f; //Porque eh 2d
		if (dir != Vector3.zero) {
			vermelhoTransform.rotation = Quaternion.Slerp (vermelhoTransform.rotation,
			                                         Quaternion.FromToRotation (Vector3.right, dir), rotationSpeed * Time.deltaTime);
		}
		float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
	}

	//Funcao de movimento
	void Mover() {
		Vector2 vermelhoPosicao = vermelhoTransform.position;
		Vector2 dir = alvoVermelho.position - vermelhoTransform.position;
		transform.position = new Vector2(vermelhoPosicao.x+dir.x*moveSpeed*Time.deltaTime, vermelhoPosicao.y+dir.y*moveSpeed*Time.deltaTime);
	}

	//Funcao que checa se ele esta morto para mudar de fase
	void ChecaVida() {
		if (hpVermelho < 1) Application.LoadLevel ("fim"); 
	}
}
