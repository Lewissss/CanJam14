using UnityEngine;
using System.Collections;

public class AsyncScene : MonoBehaviour {

	public Texture2D emptyProgressBar;
	public Texture2D fullProgressBar;
	public string levelName;

	private AsyncOperation async = null;

	// Use this for initialization
	IEnumerator Start() {
		async = Application.LoadLevelAsync(levelName);
		yield return async;
		Debug.Log("Loading complete");
	}
	
	void OnGUI(){

		if(async != null){
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 100, 50), emptyProgressBar);
			GUI.DrawTexture(new Rect(Screen.width / 2, Screen.height / 2, 100 * async.progress, 50), fullProgressBar);
		}
	}
}
