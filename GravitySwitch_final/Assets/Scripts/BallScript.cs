using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

	public float force = 10;
	public float angle = 45;
	public float torque = 10;

	Vector2 ballForce = new Vector2();

	void Start () {
		ballForce.x = force * Mathf.Cos (Mathf.Deg2Rad * angle);
		ballForce.y = force * Mathf.Sin (Mathf.Deg2Rad * angle);
	}
	
	// Update is called once per frame
	void OnMouseDown(){
		this.rigidbody2D.AddForce (ballForce);
		this.rigidbody2D.AddTorque (torque);
	}
}
