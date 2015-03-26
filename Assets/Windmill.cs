using UnityEngine;
using System.Collections;

public class Windmill : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Transform wings = transform.FindChild("top1").FindChild("wings");
		wings.Rotate(new Vector3(0, 0, 2));
	}
}
