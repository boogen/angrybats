using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour {

	bool initialized = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!initialized && Input.GetMouseButtonDown(0)) {
			initialized = true;
			GameObject.Find("micro_bat_1").AddComponent<CameraFollow>();
		}
	}
}
