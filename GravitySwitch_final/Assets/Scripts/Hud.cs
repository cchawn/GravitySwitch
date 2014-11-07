using UnityEngine;
using System.Collections;

public class Hud : MonoBehaviour {

	Animator anim; //reference to animator
	public GameObject otherGameObject;
	private CharachterController characterController;
	private float counter;
	private float height = Screen.height;
	private float width = Screen.width;
	private float xpos;
	private float ypos; 
	void Awake()
	{
		characterController = otherGameObject.GetComponent<CharachterController>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter = characterController.Oxygenlvl;
	}

	void OnGUI() //called every frame
	{	
		xpos = width * ((float)(0.628298675));
		ypos = height * ((float)(0.868204893)); 
		GUI.Label (new Rect ((xpos), ypos, 100, 30), "Oxygen level: " + (int)(counter));
	}

	void Update()
	{
		height = Screen.height;
		width = Screen.width;

	}
}
