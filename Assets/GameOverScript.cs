using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public Texture2D wizardbaixo;
	public Texture2D wizardcima;

	void OnGUI() {
		
		GUIStyle gameOver = new GUIStyle (GUI.skin.box);
		gameOver.fontSize = 60;
		GUIStyle texto = new GUIStyle (GUI.skin.box);
		texto.fontSize = 20;
		GUIStyle botaoVoltar = new GUIStyle (GUI.skin.button);
		botaoVoltar.fontSize = 20;
		
		GUI.Box (new Rect (Screen.width / 2 - 200, Screen.height / 2 - 200, 400, 150), "GAME OVER", gameOver);
		GUI.Label(new Rect (Screen.width / 2 - 400, Screen.height / 2 - 200, 150, 150), wizardbaixo);
		GUI.Label(new Rect (Screen.width / 2 + 300, Screen.height / 2 - 200, 150, 150), wizardcima);

		GUI.Box (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 20, 150, 40), "Perdeste!", texto);
		GUI.Box (new Rect (Screen.width / 2 - 150, Screen.height / 2 + 20, 300, 40), "Boa sorte na proxima vez!", texto);

		bool voltarParaMenu = GUI.Button (new Rect (Screen.width / 2 - 125, Screen.height / 2 + 200, 250, 40), "Eu aceito minha derrota.", botaoVoltar);

		if (voltarParaMenu) {	
			Application.LoadLevel ("menu"); 	
		}
		
	}
}
