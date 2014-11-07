using UnityEngine;
using System.Collections;

public class Level1Button : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect lvl1Button;
	
	Rect menuAreaNormalized;

	private float height;
	private float width;
	
	void OnGUI()
	{
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		lvl1Button.x = (width / 2) - 70;
		lvl1Button.y = (height / 2);
		
		if (GUI.Button (new Rect (lvl1Button), ""))
			Application.LoadLevel (2);
		GUI.EndGroup ();

	}

	
	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
	}

}
