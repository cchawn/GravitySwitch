using UnityEngine;
using System.Collections;

public class getLife : MonoBehaviour {

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
		counter = characterController.lifeCount;
		anim.SetFloat ("LifeCount", counter); //determines how fast moivng up or down
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		counter = characterController.lifeCount;
		anim.SetFloat ("LifeCount", counter);

	}
}
