using UnityEngine;
using System.Collections;

public class ConfScript : MonoBehaviour {

	void OnGUI() {

		GUIStyle fonte = new GUIStyle (GUI.skin.box);
		fonte.fontSize = 25;
		GUIStyle cores = new GUIStyle (GUI.skin.button);
		cores.fontSize = 25;

		GUI.Box (new Rect (Screen.width / 2 - 100, Screen.height / 2 - 200, 200, 100), "Cor do tiro:", fonte);
		
		bool corVermelho = GUI.Button (new Rect (Screen.width / 2 - 75, Screen.height / 2 - 100 , 150, 50), "Vermelho", cores);
		bool corVerde = GUI.Button (new Rect (Screen.width / 2 - 60, Screen.height / 2 - 50, 120, 50), "Verde", cores);
		bool corAzul = GUI.Button (new Rect (Screen.width / 2 - 50, Screen.height / 2 , 100, 50), "Azul", cores);
		bool voltar = GUI.Button (new Rect (Screen.width / 2 - 65, Screen.height / 2 + 200, 130, 50), "Voltar", cores);

		if (corVermelho) {	
			PlayerPrefs.SetInt("Cor do Tiro", 3);
			print("vermelho");
		}
		
		if (corVerde) {
			PlayerPrefs.SetInt("Cor do Tiro", 1);
			print("verde");
		}
		
		if (corAzul) {
			PlayerPrefs.SetInt("Cor do Tiro", 2);
			print("azul");
		}

		if (voltar) {
			Application.LoadLevel ("menu");
		}

	}
}
