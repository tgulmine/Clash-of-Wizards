using UnityEngine;
using System.Collections;

public class PreFaseVermelhoScript : MonoBehaviour {

	public Texture2D wizardVermelho;
	
	void OnGUI() {
		
		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoBatalhar = new GUIStyle (GUI.skin.button);
		botaoBatalhar.fontSize = 30;

		//GUI da pre fase 3
		GUI.Label(new Rect (Screen.width / 2 - 60, Screen.height / 2 - 150, 120, 120), wizardVermelho);
		
		GUI.Box (new Rect (Screen.width / 2 - 300, Screen.height / 2 - 20, 600, 40), "Pode ter derrotado os outros, mas eu sou o melhor.", texto);

		//Botao para começar a fase
		bool batalhar = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 40), "BATALHAR", botaoBatalhar);
		
		if (batalhar) {	
			Application.LoadLevel ("fase3"); 	
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
