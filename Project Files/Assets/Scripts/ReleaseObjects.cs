using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ReleaseObjects : MonoBehaviour {

	private List<GameObject> childList = new List<GameObject>();

	void Start(){

		foreach(Transform child in transform){
			childList.Add (child.gameObject);
		}
	}

	public void Release(int count){

		List<GameObject> tempList = new List<GameObject>();

		for(int i = 0; i < count; i++){

			int value = Random.Range(0, childList.Count);
			tempList.Add (childList[value]);
			childList.RemoveAt(value);

		}

		foreach(GameObject child in tempList){

			child.transform.parent = null;
			child.AddComponent<BoxCollider>();
			child.AddComponent<LifeCycle>();

			if(child.rigidbody == null){
				child.AddComponent<Rigidbody>();
			}
	
			child.rigidbody.collisionDetectionMode = CollisionDetectionMode.Discrete;

		}
	}
	
	
}