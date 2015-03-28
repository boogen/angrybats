using UnityEngine;
using System.Collections;

public class NewBehaviourScript1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
				Rigidbody rb = GetComponent<Rigidbody> ();
				rb.AddForce(new Vector3(-300, 700, 0));
	}


	// Update is called once per frame
	void Update () {
	
	}
}
