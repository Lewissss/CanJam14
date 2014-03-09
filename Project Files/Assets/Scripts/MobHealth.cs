using UnityEngine;
using System.Collections;

public class MobHealth : MonoBehaviour {

	private int MaxCubeCount;
	private int currentCubeCount;
	private int minimalValue;
	private float health;
	public float maxHealth;

	// Use this for initialization
	void Start () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {

		if(health <= 0){
			Kill ();
		}
	}

	private void Kill(){

		GetComponent<ReleaseObjects>().Release(transform.childCount);
		gameObject.collider.enabled = false;
		if(gameObject.GetComponent<CharacterController>() != null){
			gameObject.GetComponent<CharacterController>().collider.enabled = false;
		}
		gameObject.AddComponent<LifeCycle>();
	}

	public void Damage(float damage){
		health -= damage;
	}

}
