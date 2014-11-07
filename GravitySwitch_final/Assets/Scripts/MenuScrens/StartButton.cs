using UnityEngine;
using System.Collections;

public class StartButton : MonoBehaviour {

	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;

	private float height;
	private float width;

	Rect menuAreaNormalized;


	void OnGUI (){
		GUI.skin = menuSkin;
		GUI.BeginGroup (menuArea);

		playButton.x = (width / 2) - 87;
		playButton.y = (height / 2) - 15;

		if (GUI.Button (new Rect (playButton), ""))
			Application.LoadLevel (2);

		GUI.EndGroup ();
		}

	void FixedUpdate (){
		height = Screen.height;
		width = Screen.width;
		}

}
