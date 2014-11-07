using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {	
	void OnGUI()
	{
		GUI.Label (new Rect(Screen.width / 2 - 40,50,80,30), "GAME OVER");
		GUI.Label (new Rect(Screen.width / 2 - 30,320,80,30), "Play Again?");
		if(GUI.Button(new Rect(Screen.width / 2 - 60, 350,60, 30), "Yes?"))
			Application.LoadLevel ("MainMenu"); 
		if (GUI.Button (new Rect (Screen.width / 2 + 10, 350, 60, 30), "No?")) {
			Application.Quit (); //If you are running it in the editor it won't quit your application but it will when you do a stand-alone build.
				}
	}
}
