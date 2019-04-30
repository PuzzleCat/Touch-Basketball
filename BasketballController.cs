using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BasketballController : MonoBehaviour {
	
	public Text score;
	public Text AIScore;
	public Text done;
	public GameObject arrow;
	public GameObject BlackHoop;
	public AudioClip bounce;
	public GameObject ThumbsUpLeft;
	public GameObject ThumbsUpRight;
	
	private int count;
	private int AICount;
	private Vector2 start;
	private Vector2 end;
	private Rigidbody2D rb;
	private Vector3 iniRot;
	private bool win;
	private bool lose;
	private Vector2 target;
	private Vector2 self;
	private bool down;
	private AudioSource source;
	private Vector3 begin;

	void Start () {
		down = false;
		count = 0;
		score.text = "Score: " + count;
		AICount = 0;
		AIScore.text = "AI Score: " + AICount;
		done.text = "";
		rb = GetComponent<Rigidbody2D> ();
		win = false;
		lose = false;
		source = GetComponent<AudioSource> ();
		begin = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (rb.velocity.y <= 0) {
			down = true;
		}
		else{
			down = false;
		}
		if (other.gameObject.CompareTag ("Wall")) {
			source.PlayOneShot (bounce, (rb.velocity.magnitude) * 0.05f);
		}
	}

	void OnTriggerExit2D(Collider2D other){
		if (rb.velocity.y < 0 && down == true) {
			if (other.gameObject.CompareTag ("Hoop")) {
				count = count + 1;
				score.text = "Score: " + count;
				if (count == 10 && lose == false) {
					done.text = "You Win!";
					win = true;
					ThumbsUpLeft.SetActive(true);
					ThumbsUpRight.SetActive(true);
				}
			} else if (other.gameObject.CompareTag ("Black Hoop")) {
				AICount = AICount + 1;
				AIScore.text = "AIScore: " + AICount;
				if (AICount == 10 && win == false) {
					done.text = "You Lose!";
					lose = true;
				}
			}
		}
		down = false;
	}

	void OnCollisionExit2D(Collision2D other){
		if (other.gameObject.CompareTag ("Alien")) {
			target = new Vector2 (BlackHoop.transform.position.x, BlackHoop.transform.position.y);
			self = new Vector2 (transform.position.x, transform.position.y);
			rb.AddForce ((target-self), ForceMode2D.Impulse);
		}
	}

	void OnMouseDown(){
		start = Input.mousePosition;
		rb.isKinematic = true;
		end = Input.mousePosition;
		float r = -transform.eulerAngles.z;
		iniRot = new Vector3 (0.0f, 0.0f, r);
		transform.Rotate (iniRot, Space.World);
		arrow.transform.localScale = ((end - start)*0.03f);
		arrow.SetActive (true);
	}

	void OnMouseDrag(){
		end = Input.mousePosition;
		arrow.transform.localScale = ((end - start) * 0.03f);
	}

	void OnMouseUp(){
		rb.isKinematic = false;
		end = Input.mousePosition;
		rb.AddForce (end - start, ForceMode2D.Impulse);
		arrow.SetActive (false);
	}

	public void Reset(){
		rb.velocity = Vector3.zero;
		transform.position = begin;
	}

}
