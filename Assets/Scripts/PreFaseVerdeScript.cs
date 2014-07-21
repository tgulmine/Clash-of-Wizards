using UnityEngine;
using System.Collections;

public class PreFaseVerdeScript : MonoBehaviour {

	public Texture2D wizardVerde;
	
	void OnGUI() {
		
		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoBatalhar = new GUIStyle (GUI.skin.button);
		botaoBatalhar.fontSize = 30;

		//GUI da pre fase 2
		GUI.Label(new Rect (Screen.width / 2 - 60, Screen.height / 2 - 150, 120, 120), wizardVerde);
		
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 20, 400, 40), "Tem certeza que quer me enfrentar?", texto);

		//Botao para começar a fase
		bool batalhar = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 40), "BATALHAR", botaoBatalhar);
		
		if (batalhar) {	
			Application.LoadLevel ("fase2"); 	
		}
		
	}

	void Start() {
		//Reseta os valores globais
		PlayerScript.hpPlayer = 100;
		PlayerScript.cdTeleporte = false;
		Atirar.cdTiro = false;
		Atirar.cdSuperTiro = false;
	}
}
