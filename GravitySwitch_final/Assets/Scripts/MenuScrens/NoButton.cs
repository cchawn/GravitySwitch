using UnityEngine;
using System.Collections;

public class NoButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect noButton;
	
	private float height;
	private float width;
	
	Rect menuAreaNormalized;
	
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);
		
		noButton.x = (width / 2) - 225;
		noButton.y = (height / 2);
		
		if (GUI.Button (new Rect (noButton), ""))
			Application.LoadLevel (0);
		
		GUI.EndGroup ();
	}
	
	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
