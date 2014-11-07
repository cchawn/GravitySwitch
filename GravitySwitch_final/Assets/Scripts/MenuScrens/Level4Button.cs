using UnityEngine;
using System.Collections;

public class Level4Button : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvl4Button;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		lvl4Button.x = (width / 2) + 35;
		lvl4Button.y = (height / 2);
		
		if (GUI.Button (new Rect (lvl4Button), ""))
			Application.LoadLevel (6);

		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
