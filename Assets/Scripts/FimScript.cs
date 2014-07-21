using UnityEngine;
using System.Collections;

public class FimScript : MonoBehaviour {

	public Texture2D ending;
	
	void OnGUI() {
		
		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoRetornar = new GUIStyle (GUI.skin.button);
		botaoRetornar.fontSize = 30;

		//Mostra imagem da ending
		GUI.Label(new Rect (Screen.width / 2 - 116, Screen.height / 2 - 300, 250, 300), ending);

		//Mostra texto
		GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 - 20, 500, 40), "Provou ser o melhor de todos, sendo respeitado,", texto);
		GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 20, 500, 40), "admirado e mesmo temido entre os 7 mundos.", texto);
		GUI.Box (new Rect (Screen.width / 2 - 250, Screen.height / 2 + 120, 500, 40), "Seguiu seu caminho para um universo superior.", texto);

		//Botao que retorna ao menu
		bool retornarParaMenu = GUI.Button (new Rect (Screen.width / 2 - 45, Screen.height / 2 + 200, 90, 45), "FIM", botaoRetornar);
		
		if (retornarParaMenu) {	
			Application.LoadLevel ("menu"); 	
		}
		
	}
}
