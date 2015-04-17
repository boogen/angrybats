using UnityEngine;
using System.Collections;

public class Kamera : MonoBehaviour {

	public Vector3 offset;
	public Quaternion rotation;
	// Use this for initialization
	void Start () {
		offset = transform.position;
		rotation = transform.rotation;
	}

}
