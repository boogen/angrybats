﻿using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		int i = 500;
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(i, i, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
