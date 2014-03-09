using UnityEngine;
using System.Collections;

public class SimpleMovement : MonoBehaviour {

	private CharacterController controller;
	private Vector3 moveDirection;
	private float speed = 5.0f;
	private Transform target;
	
	// Use this for initialization
	void Start () {
		target = GameObject.Find("Player").transform;
		controller = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		

		transform.LookAt(target);
			
		if(GetComponent<CharacterController>().enabled){
			if(Vector3.Distance(transform.position, target.position) > 8 && Vector3.Distance(transform.position, target.position) < 20){
				moveDirection = transform.TransformDirection(Vector3.forward);
				controller.SimpleMove(moveDirection * speed);
			}
		}

	}

}
