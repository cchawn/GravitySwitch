using UnityEngine;
using System.Collections;

public class TutorialButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect tutorialButton;
	
	Rect menuAreaNormalized;
	
	private float height;
	private float width;

	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		tutorialButton.x = (width / 2) - 87;
		tutorialButton.y = (height / 2) - 15 + 105;
		
		if (GUI.Button (new Rect (tutorialButton), ""))
			Application.LoadLevel (9);

		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
