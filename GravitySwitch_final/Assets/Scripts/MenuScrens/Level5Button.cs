using UnityEngine;
using System.Collections;

public class Level5Button : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvl5Button;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		lvl5Button.x = (width / 2) + 70;
		lvl5Button.y = (height / 2);
		
		if (GUI.Button (new Rect (lvl5Button), ""))
			Application.LoadLevel (7);

		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}
}
