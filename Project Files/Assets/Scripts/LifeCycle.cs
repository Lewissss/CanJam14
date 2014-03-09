using UnityEngine;
using System.Collections;

public class LifeCycle : MonoBehaviour {

	private float currentTime = 0f;
	private float maxLife = 3f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
		currentTime += Time.deltaTime;

		if(currentTime > maxLife){
			if(gameObject.rigidbody != null){
				gameObject.rigidbody.detectCollisions = false;
				gameObject.rigidbody.isKinematic = false;
			}

			gameObject.collider.enabled = false;
			
		}

		if(transform.position.y < -1){
			Destroy(gameObject);
		}
		
		if(currentTime >= maxLife + 2){
			Destroy(gameObject);
		}

	}
}
