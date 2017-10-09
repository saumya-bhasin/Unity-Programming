using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	private Rigidbody rb;
	private int count;
	public Text countText;
	public Text winText;

	void Start(){
		rb = GetComponent<Rigidbody> ();
		count = 0;
		SetcountText();
		winText.text = "";
	}

	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);

	}
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag("Pick Up")){
			other.gameObject.SetActive(false);
			count += 1;
			SetcountText ();

		}
	}

	void SetcountText(){
		countText.text = "Count: " + count.ToString ();
		if (count >= 8) {
			winText.text = "YOU WIN!";
		}
			
	}
}
