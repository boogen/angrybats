using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = new Vector3(0, Camera.main.transform.position.y, Camera.main.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		Camera.main.transform.position = new Vector3(Mathf.Lerp(Camera.main.transform.position.x, this.transform.position.x, Time.deltaTime * 4f), offset.y, offset.z);
	}
}
