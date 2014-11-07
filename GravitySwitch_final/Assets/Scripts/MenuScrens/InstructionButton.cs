using UnityEngine;
using System.Collections;

public class InstructionButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect instrButton;

	private float height;
	private float width;
	
	Rect menuAreaNormalized;
	
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		instrButton.x = (width / 2) - 87;
		instrButton.y = (height / 2) - 15 + 35;
		
		if (GUI.Button (new Rect (instrButton), "")) {
			Application.LoadLevel (1);
				}		
		
		
		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}

}
