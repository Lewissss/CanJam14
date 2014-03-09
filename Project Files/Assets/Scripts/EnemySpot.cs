using UnityEngine;
using System.Collections;

public class EnemySpot : MonoBehaviour {

	Ray ray;
	RaycastHit hit;
	Vector3 foward;
	public float distance = 50;

	public GameObject arrowPrefab;
	public GameObject arrowSpawn;

	public float currentTime;
	public float maxInterval = 3f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		ray = new Ray(arrowSpawn.transform.position, transform.TransformDirection(Vector3.forward));
		Debug.DrawRay(arrowSpawn.transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);
		if(Physics.Raycast(ray, out hit, distance)){

			Debug.Log (hit.collider.gameObject.name);

			if(hit.collider.gameObject.name == "Player"){
				Debug.Log ("HIT!");
				Shoot();
			}
		}

	}


	void Shoot(){

		Debug.Log ("Arrow fired!");

		ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
		RaycastHit hit;
		Vector3 dir;

		dir = ray.direction;
		
		Quaternion rot = Quaternion.FromToRotation(arrowSpawn.transform.forward, ray.direction);
		
		Rigidbody projectile = Instantiate(arrowPrefab, arrowSpawn.transform.position, rot) as Rigidbody;
		projectile.rigidbody.velocity = dir * 2000f;
		projectile.gameObject.AddComponent<LifeCycle>();
		projectile.GetComponent<Projectile>().setDamage(20f);
	}
}
