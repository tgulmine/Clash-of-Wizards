using UnityEngine;
using System.Collections;

public class InicioJogo : MonoBehaviour {

	void OnGUI() {
		
		GUIStyle inicioJogo = new GUIStyle (GUI.skin.box);
		inicioJogo.fontSize = 60;
		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoIniciar = new GUIStyle (GUI.skin.button);
		botaoIniciar.fontSize = 40;

		//Gui do inicio do jogo
		GUI.Box (new Rect (Screen.width / 2 - 400, Screen.height / 2 - 200, 800, 150), "A JORNADA VAI COMEÇAR", inicioJogo);
		
		GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 20, 500, 40), "Lute na arena para provar seu poder", texto);
		GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 20, 500, 40), "como melhor mago de todos os tempos.", texto);

		//Botao para comecar a primeira fase
		bool comecarJogo = GUI.Button (new Rect (Screen.width / 2 - 100, Screen.height / 2 + 200, 200, 50), "INICIAR", botaoIniciar);
		
		if (comecarJogo) {	
			Application.LoadLevel ("prefase1"); 	
		}
		
	}
}
