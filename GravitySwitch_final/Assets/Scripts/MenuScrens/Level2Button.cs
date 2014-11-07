using UnityEngine;
using System.Collections;

public class Level2Button : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvl2Button;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		lvl2Button.x = (width / 2) - 35;
		lvl2Button.y = (height / 2);
		
		if (GUI.Button (new Rect (lvl2Button), ""))
			Application.LoadLevel (3);

		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
