using UnityEngine;
using System.Collections;

public class ClickStart : MonoBehaviour {

	public GameObject button;

	// Use this for initialization
	void Start () {
		button.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseUpAsButton(){
		button.SetActive (true);
	}
}
