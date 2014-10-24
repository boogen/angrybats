using UnityEngine;
using System.Collections;

public class Bat : MonoBehaviour {

	bool shot = false;
	float time = 0f;
	LineRenderer leftLine;
	LineRenderer rightLine;
	bool dragged = false;
	GameObject slingshot;
	Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();

		slingshot = GameObject.Find("slingshot");

		Transform left = slingshot.transform.FindChild("left");
		Transform right = slingshot.transform.FindChild("right");

		leftLine = left.gameObject.GetComponent<LineRenderer>();
		rightLine = right.gameObject.GetComponent<LineRenderer>();
		leftLine.SetPosition(0, left.position);
		rightLine.SetPosition(0, right.position);
		leftLine.SetPosition(1, this.transform.position);
		rightLine.SetPosition(1, this.transform.position);
	}

	void OnMouseDown() {
		dragged = true;
	}

	void OnMouseUp() {
		dragged = false;

		rigidbody.isKinematic = false;

		Transform middle = slingshot.transform.FindChild("middle");
		Vector3 diff = middle.position - transform.position;

		rigidbody.AddForce(diff * 400);
		shot = true;
		GetComponent<TrailRenderer>().enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (dragged) {
			Vector3 pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 3));
			pos.z = 5;

			Transform middle = slingshot.transform.FindChild("middle");
			Vector3 diff = pos - middle.position;
			if (diff.magnitude > 2) {
				diff.Normalize();
				diff *= 2;
				transform.position = middle.position + diff;
			}
			else {
				transform.position = pos;
			}

			leftLine.SetPosition(1, this.transform.position);
			rightLine.SetPosition(1, this.transform.position);
		}



		if (shot) {
			time += Time.deltaTime;
			if (time >= 5) {
				this.enabled = false;
				this.gameObject.GetComponent<CameraFollow>().enabled = false;
				GameObject nextBat = GetComponent<NextBat>().bat;
				if (nextBat != null) {
					nextBat.AddComponent<CameraFollow>();
					nextBat.AddComponent<Bat>();
					nextBat.transform.Rotate(new Vector3(0, -90, 0));
					nextBat.transform.position = new Vector3(13, 0.59f, 5f);
				}
			}
		}
	}
}
