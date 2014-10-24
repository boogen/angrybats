using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	bool dead = false;
	// Use this for initialization
	void Start () {

	}

	void OnCollisionEnter(Collision collision) {
		Rigidbody rb1 = collision.gameObject.GetComponent<Rigidbody>();
		Rigidbody rb2 = gameObject.GetComponent<Rigidbody>();
		if (rb1 != null && rb1.velocity.magnitude > 10) {
			GameObject.Destroy(this.gameObject);
		}
		else if (rb2.velocity.magnitude > 1) {
			die();
		}

	}

	void die() {
		Transform mesh = gameObject.transform.FindChild("Orc mesh");
		mesh.gameObject.GetComponent<SkinnedMeshRenderer>().enabled = false;
		GameObject.Destroy(gameObject.GetComponent<Rigidbody>());
		GameObject.Destroy(gameObject.GetComponent<SphereCollider>());
		gameObject.transform.FindChild("puff").GetComponent<ParticleSystem>().Play();
		dead = true;
	}

	// Update is called once per frame
	void Update () {
		if (dead && !gameObject.transform.FindChild("puff").GetComponent<ParticleSystem>().IsAlive()) {
			GameObject.Destroy(this.gameObject);
		}
	}
}
