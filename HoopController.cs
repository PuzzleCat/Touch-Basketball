using UnityEngine;
using System.Collections;

public class HoopController : MonoBehaviour {

	public int speed;

	private bool up;
	private float posY;

	void Start () {
		up = true;
		posY = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		posY = transform.position.y;
		if (posY < 23.0f && up == true) {
			transform.position += Vector3.up*Time.deltaTime*speed;
		} else if (posY >= 23.0f) {
			up = false;
			transform.position += Vector3.down*Time.deltaTime*speed;
		} else if (posY > -23.0f && up == false) {
			transform.position += Vector3.down*Time.deltaTime*speed;
		} else if (posY <= -23.0f) {
			up = true;
			transform.position += Vector3.up*Time.deltaTime*speed;
		}
	}
}
