using UnityEngine;
using System.Collections;

public class BrushScript : MonoBehaviour {

	public float veloicty = 1.0f;

	void Update () {
		if (Input.GetKey (KeyCode.RightArrow))
			this.transform.position += Vector3.right * veloicty * Time.deltaTime;
		if(Input.GetKey (KeyCode.LeftArrow))
			this.transform.position -= Vector3.right * veloicty * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.name != "BackGround") {
			SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer> ();
			sr.color = Color.gray;
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (other.gameObject.name != "BackGround") {
			SpriteRenderer sr = other.gameObject.GetComponent<SpriteRenderer>();
			sr.color = Color.white;
		}
	}
}
