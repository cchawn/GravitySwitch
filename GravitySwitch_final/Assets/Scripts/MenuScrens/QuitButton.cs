using UnityEngine;
using System.Collections;

public class QuitButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect quitButton;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);
		
		quitButton.x = (width / 2) - 87;
		quitButton.y = (height / 2) - 15 + 140;

		if (GUI.Button (new Rect (quitButton), ""))
			Application.Quit ();			

		GUI.EndGroup ();
	}
	
	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
