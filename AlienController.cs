using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlienController : MonoBehaviour {
	
	public float speed;
	public GameObject ball;

	private Rigidbody2D rb;
	private Vector2 movement;
	private Vector2 target;
	private Vector2 self;
	
	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		
		float h = Random.value;
		float v = Random.value;
		
		float moveHorizontal = h * 2 - 1;
		float moveVertical = v * 2 - 1;
		
		movement = new Vector2 (moveHorizontal, moveVertical);
		
		//rb.velocity = movement * speed;
	}

	void Update(){
		target = new Vector2 (ball.transform.position.x, ball.transform.position.y);
		self = new Vector2 (transform.position.x, transform.position.y);
		rb.AddForce ((target-self)*0.1f, ForceMode2D.Force);
	}

	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.CompareTag ("Wall")) {
			float Horizontal = Random.value * 2 - 1;
			float Vertical = Random.value * 2 - 1;
			movement = new Vector2 (Horizontal, Vertical);
			rb.velocity = movement * speed * 3.0f;
		} 
		else if (other.gameObject.CompareTag ("Alien")) {
			float Horizontal = Random.value * 2 - 1;
			float Vertical = Random.value * 2 - 1;
			movement = new Vector2 (Horizontal, Vertical);
			rb.velocity = movement * speed;
		} 
		else if (other.gameObject.CompareTag ("Ball")) {
			float Horizontal = Random.value * 2 - 1;
			float Vertical = Random.value * 2 - 1;
			movement = new Vector2 (Horizontal, Vertical);
			rb.velocity = movement * speed;
		}
	}
}
