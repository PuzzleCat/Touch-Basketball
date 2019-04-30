using UnityEngine;
using System.Collections;

public class CoverController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		StartCoroutine (delay ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator delay(){
		yield return new WaitForSeconds (3);
		Application.LoadLevel ("Start");

	}
}
