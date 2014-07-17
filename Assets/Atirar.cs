using UnityEngine;
using System.Collections;

public class Atirar : MonoBehaviour
{

	public GameObject tiro;
	Vector3 mousePos;
	Vector3 pos;
	public float speedTiro;
	private bool cdBolaFogo=false;

	public AudioClip fire1;

	private PlayerScript playerScript;

	void Awake ()
	{
		playerScript = tiro.GetComponent<PlayerScript>();
	}

	// Update is called once per frame
	void Update ()
	{
		BolaFogo();

	}

	void BolaFogo() {
		if (Input.GetMouseButtonDown(0) && cdBolaFogo == false)
		{	
			mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			mousePos.z = 0;
			pos = mousePos;
			//gameObject.collider2D.enabled = false;

			GameObject tiroClone = (GameObject) Instantiate(tiro, transform.position, Quaternion.identity);

			if (PlayerPrefs.GetInt("Cor do Tiro") == 3) { 
				tiroClone.GetComponent<SpriteRenderer>().color = Color.red;
			}
			
			else if (PlayerPrefs.GetInt("Cor do Tiro") == 1) { 
				tiroClone.GetComponent<SpriteRenderer>().color = Color.green;
			}
			
			else if (PlayerPrefs.GetInt("Cor do Tiro") == 2) { 
				tiroClone.GetComponent<SpriteRenderer>().color = Color.blue;
			}

			float x,y,z;

			x = pos.x-transform.position.x;
			y = pos.y-transform.position.y;

			z = Mathf.Sqrt(Mathf.Pow(x,2)+Mathf.Pow(y,2));

			tiroClone.rigidbody2D.AddForce(new Vector2(x/z*speedTiro, y/z*speedTiro));
			StartCoroutine("CdBolaFogo");
			print (pos.x-transform.position.x);
			print(pos.y-transform.position.y);
			cdBolaFogo = true;

		}
	}



	void OnCollisionEnter(Collision collision){
				if (collision.gameObject.name == "Personagem") {
						Destroy (this.gameObject);
			print(playerScript.hpPlayer);
				}

	
				
		}



	IEnumerator CdBolaFogo() {
		yield return new WaitForSeconds(4);
		cdBolaFogo = false;
	}
	

}