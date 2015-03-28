using UnityEngine;
using System.Collections;

public class lol : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody> ();
		rb.AddForce (new Vector3 ( 0, 0, 500));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
