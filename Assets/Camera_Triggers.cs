using UnityEngine;
using System.Collections;

public class Camera_Triggers : MonoBehaviour {
	public GameObject target;
	void OnTriggerEnter(Collider other){
		if (other.tag == "MainCollider") {
			target.SetActive (true);
			gameObject.SetActive (false);
		}
	}
}
