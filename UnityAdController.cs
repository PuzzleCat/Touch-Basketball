using UnityEngine;
using System.Collections;
using UnityEngine.Advertisements;

public class UnityAdController : MonoBehaviour
{
	// Serialize private fields
	//  instead of making them public.
	[SerializeField] string iosGameId = "1128638";
	[SerializeField] string androidGameId = "1128639";
	[SerializeField] bool enableTestMode;
	
	void Start ()
	{
		string gameId = null;
		
		#if UNITY_IOS // If build platform is set to iOS...
		gameId = iosGameId;
		#elif UNITY_ANDROID // Else if build platform is set to Android...
		gameId = androidGameId;
		#endif

		if (string.IsNullOrEmpty (gameId)) { // Make sure the Game ID is set.
			Debug.LogError ("Failed to initialize Unity Ads. Game ID is null or empty.");
		} else if (!Advertisement.isSupported) {
			Debug.LogWarning ("Unable to initialize Unity Ads. Platform not supported.");
		} else if (Advertisement.isInitialized) {
			Debug.Log ("Unity Ads is already initialized.");
		} else {
			Debug.Log (string.Format ("Initialize Unity Ads using Game ID {0} with Test Mode {1}.",
				                          gameId, enableTestMode ? "enabled" : "disabled"));
			Advertisement.Initialize (gameId, enableTestMode);
		}
		if (Advertisement.isReady () == true) {
			Advertisement.Show ();
		} else {
			StartCoroutine (wait ());
		}
		PlayerPrefs.SetInt ("Return", 0);

	}
	IEnumerator wait(){
		yield return new WaitForSeconds (1);
		if (Advertisement.isReady() == true) {
			Advertisement.Show ();
		} else {
			wait ();
		}
	}
}