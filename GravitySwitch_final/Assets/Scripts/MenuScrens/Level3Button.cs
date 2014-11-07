using UnityEngine;
using System.Collections;

public class Level3Button : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvl3Button;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI(){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		lvl3Button.x = (width / 2);
		lvl3Button.y = (height / 2);
		
		if (GUI.Button (new Rect (lvl3Button), ""))
			Application.LoadLevel (4);

		GUI.EndGroup ();
	}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}

}
