using UnityEngine;
using System.Collections;

public class BackButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect backButton;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		backButton.x = 10;
		backButton.y = 10;
		
		if (GUI.Button (new Rect (backButton), "")) {
			Application.LoadLevel (0);
		}
		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
