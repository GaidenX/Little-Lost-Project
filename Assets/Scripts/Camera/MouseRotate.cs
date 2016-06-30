using UnityEngine;
using System.Collections;

public class MouseRotate : MonoBehaviour {

	public Transform target;

//	private float distance = 10.0f;
	
//	private float xSpeed = 250.0f;
//	private float ySpeed = 120.0f;
	
//	private float yMinLimit = -20f;
//	private float yMaxLimit = 80f;
	
	private float x = 0.0f;
	private float y = 0.0f;
//	private float z = 0.0f;
	
	public Vector3 angles;
	
	//@script AddComponentMenu("Camera-Control/Mouse Orbit")
		
	void Start () {
		angles = transform.eulerAngles;
		x = angles.y;
		y = angles.x;
		
		// Make the rigid body not change rotation
		if (GetComponent<Rigidbody>()){
			GetComponent<Rigidbody>().freezeRotation = true;
		}
	}
	
	void Update () {
		if (target) {
			x = Input.GetAxis("Mouse X");// * xSpeed * 0.02;
			y = Input.GetAxis("Mouse Y"); //* ySpeed * 0.02;
			
		//	y = ClampAngle(y, yMinLimit, yMaxLimit);
			
			var rotation = Quaternion.Euler(y, x, 0);
		//	z = target.position;
			var position = rotation * angles ;
			
			transform.rotation = rotation;
			transform.position = position;
		}
	}
	
/*	static void ClampAngle (float angle, float min, float max) {
		if (angle < -360) {
			angle += 360;
		}
		if (angle > 360) {
			angle -= 360;
		}
		return;
			Mathf.Clamp (angle, min, max);
	} */
}