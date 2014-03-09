using UnityEngine;
using System.Collections;

public class SceneTransition : MonoBehaviour {

	public string nextScene;

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter(Collision c){


			Application.LoadLevel(nextScene);
	}

}
