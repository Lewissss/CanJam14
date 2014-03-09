using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	private float damage = 0;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setDamage(float damage){
		this.damage = damage;
	}

	void OnCollisionEnter(Collision c){

		if(c.gameObject.tag == "Mob"){
			c.gameObject.GetComponent<ReleaseObjects>().Release((int)(damage * 2f));
			c.gameObject.GetComponent<MobHealth>().Damage(damage);
		}



		gameObject.AddComponent<LifeCycle>();

		GameObject.Destroy(gameObject);
	}

}
