using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {

	public Texture2D backGUI;

	public GUIStyle skillSuperTiro;
	public GUIStyle skillTiro;
	public GUIStyle skillTeleporte;
	public GUIStyle normal;

	void OnGUI(){
		//GUI normal
		GUI.skin.label = normal;
		
		//Background da GUI
		GUI.Label(new Rect (0,Screen.height - 150,1000,700), backGUI);

		//Mostra HP do jogador
		GUI.BeginGroup(new Rect(60, Screen.height - 120, 150, 25));
			GUI.Box(new Rect (0, 0, 150, 25), "");

			GUI.backgroundColor = Color.magenta;
		
			GUI.BeginGroup(new Rect(0, 0, 1.5f*PlayerScript.hpPlayer, 25));
				GUI.Button(new Rect(0, 0, 150, 25), "");
		
				GUI.backgroundColor = Color.white;
		
			GUI.EndGroup();
		GUI.EndGroup();
		
		GUI.Label(new Rect (70, Screen.height - 120, 150, 25), "<size=20>HP: "+(int)PlayerScript.hpPlayer+" / 100</size>");

		//Mostra HP do inimigo
		if (Application.loadedLevel == 3) {
			GUI.BeginGroup (new Rect (750, Screen.height - 120, 150, 25));
			GUI.Box (new Rect (0, 0, 150, 25), "");
			
			GUI.backgroundColor = Color.blue;
		
			GUI.BeginGroup (new Rect (0, 0, 1.5f * AzulScript.hpAzul, 25));
			GUI.Button (new Rect (0, 0, 150, 25), "");
		
			GUI.backgroundColor = Color.white;
		
			GUI.EndGroup ();
			GUI.EndGroup ();
		
			GUI.Label (new Rect (760, Screen.height - 120, 150, 25), "<size=20>HP: " + (int)AzulScript.hpAzul + " / 100</size>");
		}
		if (Application.loadedLevel == 4) {
			GUI.BeginGroup (new Rect (750, Screen.height - 120, 150, 25));
			GUI.Box (new Rect (0, 0, 150, 25), "");
			
			GUI.backgroundColor = Color.green;
			
			GUI.BeginGroup (new Rect (0, 0, 1.5f * VerdeScript.hpVerde, 25));
			GUI.Button (new Rect (0, 0, 150, 25), "");
			
			GUI.backgroundColor = Color.white;
			
			GUI.EndGroup ();
			GUI.EndGroup ();
			
			GUI.Label (new Rect (760, Screen.height - 120, 150, 25), "<size=20>HP: " + (int)VerdeScript.hpVerde + " / 100</size>");
		}
		if (Application.loadedLevel == 5) {
			GUI.BeginGroup (new Rect (750, Screen.height - 120, 150, 25));
			GUI.Box (new Rect (0, 0, 150, 25), "");
			
			GUI.backgroundColor = Color.red;
			
			GUI.BeginGroup (new Rect (0, 0, 1.5f * VermelhoScript.hpVermelho, 25));
			GUI.Button (new Rect (0, 0, 150, 25), "");
			
			GUI.backgroundColor = Color.white;
			
			GUI.EndGroup ();
			GUI.EndGroup ();
			
			GUI.Label (new Rect (760, Screen.height - 120, 150, 25), "<size=20>HP: " + (int)VermelhoScript.hpVermelho + " / 100</size>");
		}

		//GUI do teleporte
		GUI.skin.toggle = skillTeleporte;
		//mostra icone do teleporte
		GUI.Toggle(new Rect (425,Screen.height - 120,100,100), PlayerScript.cdTeleporte, "<size=20>Q</size>");
		//GUI do tiro
		GUI.skin.toggle = skillTiro;
		//Mostra icone do tiro
		GUI.Toggle(new Rect (275,Screen.height - 120,100,100), Atirar.cdTiro, "<size=20>CLICK</size>");
		//GUI do super tiro
		GUI.skin.toggle = skillSuperTiro;
		//Mostra icone do super tiro
		GUI.Toggle(new Rect (575,Screen.height - 120,100,100), Atirar.cdSuperTiro, "<size=20>SPACE</size>");
		
	}

}
