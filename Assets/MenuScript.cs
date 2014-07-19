using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI() {
		
		GUIStyle nomeJogo = new GUIStyle (GUI.skin.box);
		nomeJogo.fontSize = 60;
		GUIStyle botaoJogo = new GUIStyle (GUI.skin.button);
		botaoJogo.fontSize = 25;

		GUI.Box (new Rect (Screen.width / 2 - 500, Screen.height / 2 - 200, 1000, 150), "CLASH OF WIZARDS", nomeJogo);
		
		bool abrirJogar = GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 20, 100, 50), "Jogar", botaoJogo);
		bool abrirConf = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 60, 200, 50), "Configuraçoes", botaoJogo);
		bool abrirSair = GUI.Button (new Rect (Screen.width / 2 - 70, Screen.height / 2 + 140, 140, 50), "Sair", botaoJogo);
		
		if (abrirJogar) {
			Application.LoadLevel ("fase1"); 	
		}
		
		if (abrirConf) {
			Application.LoadLevel ("conf"); 	
		}
		
		if (abrirSair) {	
			Application.Quit();	
		}
		
	}
	
	
	
	
}