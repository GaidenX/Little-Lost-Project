using UnityEngine;
using System.Collections;

public class Camera_Controller : MonoBehaviour {

	public CameraFollower cameraFollower;
	public GameObject target;
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Collider_True") {
			cameraFollower.Cam_OnCollider = false;
		}
		if (other.tag == "Collider_False") {
			cameraFollower.Cam_OnCollider = true;
		}


	}

}
