using UnityEngine;
using System.Collections;

public class ShipP1 : MonoBehaviour {

	public GameObject otherGameObject;
	private CharachterController characterController;
	public bool piece;
	private SpriteRenderer sprite;
	public int sortingOrder = -2;
	void Awake()
	{
		characterController = otherGameObject.GetComponent<CharachterController>();
		
	}
	
	// Use this for initialization
	void Start () {
		piece = characterController.haspiece1;
		sprite = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		piece = characterController.haspiece1;
		if (piece == true) {
			collider2D.isTrigger = true;
			gameObject.renderer.enabled = false;
		}

		
	}
}
