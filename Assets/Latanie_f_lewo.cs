using UnityEngine;
using System.Collections;

public class Latanie_f_lewo : MonoBehaviour {

	void Start () {
		Rigidbody ptak = GetComponent<Rigidbody> ();
		ptak.AddForce(new Vector3 (50, 0, 0));
	}

	void Update () {}
}

