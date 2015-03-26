using UnityEngine;
using System.Collections;

public class lji : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.back * Time.deltaTime * 35);

	}
}
