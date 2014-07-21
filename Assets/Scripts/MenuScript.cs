using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour {

	void OnGUI() {
		
		GUIStyle nomeJogo = new GUIStyle (GUI.skin.box);
		nomeJogo.fontSize = 60;
		GUIStyle botaoJogo = new GUIStyle (GUI.skin.button);
		botaoJogo.fontSize = 45;

		//GUI do menu
		GUI.Box (new Rect (Screen.width / 2 - 500, Screen.height / 2 - 200, 1000, 150), "CLASH OF WIZARDS", nomeJogo);

		//Botoes, um para comecar o jogo e um para fechar
		bool abrirJogar = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 30, 200, 70), "JOGAR", botaoJogo);
		bool abrirSair = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 140, 200, 70), "SAIR", botaoJogo);

		if (abrirJogar) {
			Application.LoadLevel ("iniciojogo"); 	
		}
		
		if (abrirSair) {	
			Application.Quit();	
		}
		
	}
	
	
	
	
}