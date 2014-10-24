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
		float new_x = Mathf.Max(-5f, Mathf.Min(13f,  Mathf.Lerp(Camera.main.transform.position.x, this.transform.position.x, 4 * Time.deltaTime)));
		float new_y = Mathf.Max(0.5f, Mathf.Min(3f, Mathf.Lerp(Camera.main.transform.position.y, this.transform.position.y + 1.3f, 4 * Time.deltaTime)));
		Camera.main.transform.position = new Vector3(new_x, new_y, offset.z);
	}
}
