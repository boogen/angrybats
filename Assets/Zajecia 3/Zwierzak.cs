using UnityEngine;
using System.Collections;

public class Zwierzak : MonoBehaviour {
	
	bool shot = false;
	float time = 0f;
	LineRenderer leftLine;
	LineRenderer rightLine;
	GameObject slingshot;
	Rigidbody rigidbody;
	Transform spawn;
	
	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		
		slingshot = GameObject.Find("proca");
		slingshot.GetComponent<BoxCollider>().enabled = false;
		
		Transform left = slingshot.transform.FindChild("left");
		Transform right = slingshot.transform.FindChild("right");
		
		spawn = slingshot.transform.FindChild("spawn");
		transform.position = spawn.position;
		
		leftLine = left.gameObject.GetComponent<LineRenderer>();
		rightLine = right.gameObject.GetComponent<LineRenderer>();
		leftLine.SetPosition(0, left.position);
		rightLine.SetPosition(0, right.position);
		leftLine.SetPosition(1, this.transform.position);
		rightLine.SetPosition(1, this.transform.position);
	}
	
	void OnMouseDown() {
		slingshot.GetComponent<BoxCollider>().enabled = true;
	}
	
	void OnMouseUp() {
		slingshot.GetComponent<BoxCollider>().enabled = false;
		
		rigidbody.isKinematic = false;
		
		Transform middle = slingshot.transform.FindChild("middle");
		Vector3 diff = middle.position - transform.position;
		rigidbody.AddForce(diff * slingshot.GetComponent<Proca>().moc);
		shot = true;
		GetComponent<TrailRenderer>().enabled = true;
		Camera.main.transform.parent = this.transform;
		//Camera.main.transform.position = Camera.main.GetComponent<Kamera>().offset;
		Camera.main.transform.localPosition = new Vector3(0, 0, 0);
		Camera.main.transform.localRotation = Quaternion.Euler(new Vector3(0, 0, 0));
	}
	
	// Update is called once per frame
	void Update () {
		if (slingshot.GetComponent<BoxCollider>().enabled) {
			
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 500, 1 << 12)) {
				
				Vector3 pos = hit.point;
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
			
			
			
		}
		
		
		
		if (shot) {
			time += Time.deltaTime;
			if (time >= 5) {
				this.enabled = false;
				if (GetComponent<Nastepny>() != null) {
					GameObject nextAnimal = GetComponent<Nastepny>().zwierzak;
					if (nextAnimal != null) {
						nextAnimal.AddComponent<Zwierzak>();
						Camera.main.transform.parent = slingshot.transform;
						Camera.main.transform.position = Camera.main.GetComponent<Kamera>().offset;
						Camera.main.transform.rotation = Camera.main.GetComponent<Kamera>().rotation;
						nextAnimal.transform.rotation = this.transform.rotation;
						nextAnimal.transform.position = spawn.position;
					}
				}
			}
		}
	}
}
