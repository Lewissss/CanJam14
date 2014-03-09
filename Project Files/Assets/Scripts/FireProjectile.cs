using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {

	public Rigidbody projectilePrefab;
	private Camera mainCamera;
	public GameObject projectileSpawn;
	
	public Texture2D crosshairImage;
	private float xMin;
	private float yMin;

	//Timing stuff
	private float currentTime;
	private float gapTime = 0;
	public float fireInterval = 1f;

	private bool charging = false;
	public float maxCharge = 3f;
	private int baseCharge = 10;
	private float multiplyer = 0;

	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;
		currentTime = fireInterval;
		Physics.IgnoreCollision(GameObject.Find("Player").GetComponent<CharacterController>().collider, projectilePrefab.collider);
	}

	// Update is called once per frame
	void Update () {


		if(Input.GetButtonDown("Fire1")){
			charging = true;
		}

		if(Input.GetKey (KeyCode.Escape)){
			Application.Quit();
		}

		if(charging){
			currentTime += Time.deltaTime;

			if(currentTime >= 3){
				currentTime = 3;
			}
			else{
				if(mainCamera.fieldOfView < 80){
					mainCamera.fieldOfView += 0.18f;
				}
			}

			GetComponentInChildren<ParticleEmitter>().emit = true;
		}

		if (Input.GetButtonUp("Fire1")){

			if((int)currentTime == 0){
				currentTime = 1;
			}

			switch((int)currentTime){
			case 0:
				multiplyer = 0;
				break;
			case 1:
				multiplyer = 1;
				break;
			case 2:
				multiplyer = 3f;
				break;
			case 3:
				multiplyer = 8f;
				break;
			}

		
			float actualPower = baseCharge * (int)currentTime + 10;
			Fire (actualPower, multiplyer);
			charging = false;
			currentTime = 0;
		}

		if(!charging){
			if(mainCamera.fieldOfView > 60){
				mainCamera.fieldOfView -= 1.4f;
			}

			GetComponentInChildren<ParticleEmitter>().emit = false;
		}
		
		
	}

	void OnGUI(){

		float xMin = (Screen.width / 2) - (crosshairImage.width / 2);
		float yMin = (Screen.height / 2) - (crosshairImage.height / 2);

		GUI.DrawTexture(new Rect(xMin, yMin, crosshairImage.width, crosshairImage.height), crosshairImage);
	}

	private void Fire(float power, float multiplyer){

		Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
		RaycastHit hit;
		Vector3 dir;

		if(Physics.Raycast(ray, out hit)){
			dir = (hit.point - transform.position).normalized;
		}else{
			dir = ray.direction;
		}

		Quaternion rot = Quaternion.FromToRotation(projectilePrefab.transform.forward, dir);

		Rigidbody projectile = Instantiate(projectilePrefab, projectileSpawn.transform.position, rot) as Rigidbody;
		projectile.rigidbody.velocity = dir * power;
		projectile.gameObject.AddComponent<LifeCycle>();
		projectile.GetComponent<Projectile>().setDamage(power + (baseCharge * multiplyer));

	}
}
