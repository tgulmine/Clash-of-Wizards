using UnityEngine;
using System.Collections;

public class PreFaseAzulScript : MonoBehaviour {

	public Texture2D wizardAzul;

	void OnGUI() {

		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoBatalhar = new GUIStyle (GUI.skin.button);
		botaoBatalhar.fontSize = 30;

		//GUI da pre fase 1
		GUI.Label(new Rect (Screen.width / 2 - 60, Screen.height / 2 - 150, 120, 120), wizardAzul);

		GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 20, 200, 40), "Que vença o melhor!", texto);

		//Botao para começar a fase
		bool batalhar = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 40), "BATALHAR", botaoBatalhar);
		
		if (batalhar) {	
			Application.LoadLevel ("fase1"); 	
		}
		
	}

	void Start() {
		//Reseta os valores globais
		PlayerScript.hpPlayer = 100;
		PlayerScript.cdTeleporte = false;
		PlayerScript.taNoCampo = true;
		Atirar.cdTiro = false;
		Atirar.cdSuperTiro = false;

		AzulAtirar.cdTiroAzul = false;
		AzulScript.hpAzul = 100;

		VerdeAtirar.cdTiroVerde = false;
		VerdeScript.hpVerde = 100;

		VermelhoAtirar.cdTiroVermelho = false;
		VermelhoScript.hpVermelho = 100;
	}
}
