﻿using UnityEngine;
using System.Collections;

public class isamuxbomba : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Rigidbody rb = GetComponent<Rigidbody>();
		rb.AddForce(new Vector3(-2000, 500, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
