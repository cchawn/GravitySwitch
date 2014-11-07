using UnityEngine;
using System.Collections;

public class OxygenMeter : MonoBehaviour {

	Animator anim; //reference to animator
	public GameObject otherGameObject;
	private CharachterController characterController;
	public float counter;
	void Awake()
	{
		characterController = otherGameObject.GetComponent<CharachterController>();
		
	}
	
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> (); // connects to the animator
		counter = characterController.Oxygenlvl;
		anim.SetFloat ("Oxygen Lvl", counter); //gets tank level
	}

	// Update is called once per frame
	void FixedUpdate () {
		counter = characterController.Oxygenlvl;
		anim.SetFloat ("Oxygen Lvl", counter);

		
	}
	}

