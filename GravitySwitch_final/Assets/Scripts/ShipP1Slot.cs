using UnityEngine;
using System.Collections;

public class ShipP1Slot : MonoBehaviour {

	Animator anim; //reference to animator
	public GameObject otherGameObject;
	private CharachterController characterController;
	public bool piece;
	void Awake()
	{
		characterController = otherGameObject.GetComponent<CharachterController>();
		
	}
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // connects to the animator
		piece = characterController.haspiece1;
		anim.SetBool ("HasPiece", piece); //gets tank level
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		piece = characterController.haspiece1;
		anim.SetBool ("HasPiece", piece);
		
		
	}
}
