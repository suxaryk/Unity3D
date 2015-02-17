using UnityEngine;
using System.Collections;

public class Player1 : MonoBehaviour {

	public float speed1;
	// Use this for initialization
	void FixedUpdate () 
	{
		float moveHorizontal1 = Input.GetAxis ("Horizontal");
		float moveVertical1 = Input.GetAxis ("Vertical");
		
		Vector3 movement1 = new Vector3 (moveHorizontal1, 0.0f, moveVertical1);
		
		rigidbody.AddForce (movement1 * speed1 * Time.deltaTime);
	}
}
