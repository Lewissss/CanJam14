using UnityEngine;
using System.Collections;
using Pathfinding;

public class EnemyAI : MonoBehaviour {

	private Ray eyes;
	private RaycastHit hit;
	private Vector3 forward;

	public GameObject targetObject;

	private Seeker seeker;
	private CharacterController controller;

	public Path path;

	public float speed = 100f;

	public float nextWaypointDistance = 3f;
	public int currentWaypoint = 0;

	// Use this for initialization
	void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();

		seeker.StartPath (transform.position, targetObject.transform.position, OnPathComplete);
	}


	public void OnPathComplete(Path p){
		Debug.Log ("Yay, we got a path back, did it have an error: " + p.error);
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}

	public void FixedUpdate (){

		if(path == null){
			return;
		}

		if(currentWaypoint >= path.vectorPath.Count){
			Debug.Log ("End of path reached!");
			return;
		}

		//Direction
		Vector3 dir = (path.vectorPath[currentWaypoint] -transform.position).normalized;
		transform.LookAt(targetObject.transform);
		dir *= speed * Time.fixedDeltaTime;
		controller.SimpleMove(dir);

		if(Vector3.Distance(transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance){
			currentWaypoint++;
			return;
		}
	}
}
