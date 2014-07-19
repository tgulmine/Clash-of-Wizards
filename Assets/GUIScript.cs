using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public Texture2D backGUI;
	
	public GUIStyle skillTiro;
	public GUIStyle skillTeleporte;
	public GUIStyle normal;

	void OnGUI(){
		//GUI normal
		GUI.skin.label = normal;
		
		//Background da GUI
		GUI.Label(new Rect (0,Screen.height - 150,1000,700), backGUI);
		
		//Mostra HP do jogador
		GUI.BeginGroup(new Rect(20, Screen.height - 120, 150, 25));
			GUI.Box(new Rect (0, 0, 150, 25), "");

			GUI.backgroundColor = Color.magenta;
		
			GUI.BeginGroup(new Rect(0, 0, 1.5f*PlayerScript.hpPlayer, 25));
				GUI.Button(new Rect(0, 0, 150, 25), "");
		
				GUI.backgroundColor = Color.white;
		
			GUI.EndGroup();
		GUI.EndGroup();
		
		GUI.Label(new Rect (30, Screen.height - 120, 150, 25), "<size=20>HP: "+(int)PlayerScript.hpPlayer+" / 100</size>");
		
		//Mostra HP do inimigo
		GUI.BeginGroup(new Rect(600, Screen.height - 120, 150, 25));
			GUI.Box(new Rect (0, 0, 150, 25), "");
			
			if (Application.loadedLevel == 3) GUI.backgroundColor = Color.blue;
			if (Application.loadedLevel == 4) GUI.backgroundColor = Color.green;
			if (Application.loadedLevel == 5) GUI.backgroundColor = Color.red;
		
			GUI.BeginGroup(new Rect(0, 0, 1.5f*InimigoScript.hpInimigo, 25));
				GUI.Button(new Rect(0, 0, 150, 25), "");
		
				GUI.backgroundColor = Color.white;
		
			GUI.EndGroup();
		GUI.EndGroup();
		
		GUI.Label(new Rect (610, Screen.height - 120, 150, 25), "<size=20>HP: "+(int)InimigoScript.hpInimigo+" / 100</size>");
		
		//GUI do teleporte
		GUI.skin.toggle = skillTeleporte;
		//mostra icone do teleporte
		GUI.Toggle(new Rect (350,Screen.height - 120,100,100), PlayerScript.cdTeleporte, "<size=20>Q</size>");
		//GUI do tiro
		GUI.skin.toggle = skillTiro;
		//Mostra icone do tiro
		GUI.Toggle(new Rect (200,Screen.height - 120,100,100), Atirar.cdTiro, "<size=20>CLICK</size>");
		
	}

}
