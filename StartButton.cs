using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void click(){
		Application.LoadLevel ("Main");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void clickBounce(){
		Application.LoadLevel("Bouncy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void clickNoGravity(){
		Application.LoadLevel ("NoGravity");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void clickObstacle(){
		Application.LoadLevel ("ObstacleField");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void clickBlackHole(){
		Application.LoadLevel ("BlackHole");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void home(){
		Application.LoadLevel ("Start");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void sticky(){
		Application.LoadLevel ("Sticky");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void practice(){
		Application.LoadLevel ("Practice");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

	public void crazy(){
		Application.LoadLevel ("Crazy");
		Screen.orientation = ScreenOrientation.LandscapeLeft;
	}

}
