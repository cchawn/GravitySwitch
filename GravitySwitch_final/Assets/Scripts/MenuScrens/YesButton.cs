using UnityEngine;
using System.Collections;

public class YesButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect yesButton;
	
	private float height;
	private float width;
	
	Rect menuAreaNormalized;
	
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);
		
		yesButton.x = (width / 2) + 35;
		yesButton.y = (height / 2);
		
		if (GUI.Button (new Rect (yesButton), ""))
			Application.LoadLevel (2);
		
		GUI.EndGroup ();
	}
	
	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
