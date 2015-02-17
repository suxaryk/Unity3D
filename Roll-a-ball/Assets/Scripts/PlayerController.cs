using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public Text countText;
	private int count;

	//public Text levelCount;


	void Start()
	{
		count = 0;
		SetCountText ();
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rigidbody.AddForce (movement * speed * Time.deltaTime);
	}
	void OnTriggerEnter(Collider other) 
	{
		if(other.gameObject.tag == "PickUp")
		{
				other.gameObject.SetActive(false);
				count++;
				SetCountText();
		}
	}
	void SetCountText()
	{
		countText.text = "Count: " + count.ToString();
	}
}

