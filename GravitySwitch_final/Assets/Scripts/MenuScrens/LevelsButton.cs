using UnityEngine;
using System.Collections;

public class LevelsButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvlButton;

	private float height;
	private float width;

	Rect menuAreaNormalized;
	
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);
		
		lvlButton.x = (width / 2) - 87;
		lvlButton.y = (height / 2) - 15 + 70;

		if (GUI.Button (new Rect (lvlButton), ""))
			Application.LoadLevel (8);
		
		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}

}
