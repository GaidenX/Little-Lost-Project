using UnityEngine;
using System.Collections;

public class CameraFollower : MonoBehaviour {

	/*
This camera smoothes out rotation around the y-axis and height.
Horizontal Distance to the target is always fixed.

There are many different ways to smooth the rotation but doing it this way gives you a lot of control over how the camera behaves.

For every of those smoothed values we calculate the wanted value and the current value.
Then we smooth it using the Lerp function.
Then we apply the smoothed values to the transform's position.
*/

	public Transform Look;
	// The target we are following
	public Transform target;
	// The distance in the x-z plane to the target
	public float distance;
	// the height we want the camera to be above the target
	public float height = 5.0f;
	// How much we 
	public float heightDamping = 2.0f;
	public float rotationDamping = 3.0f;

	public bool Cam_OnCollider = true;
	
	// Place the script in the Camera-Control group in the component menu
	//@script AddComponentMenu("Camera-Control/Smooth Follow");

	// Update is called once per frame
	void LateUpdate () {
		// Early out if we don't have a target
		if (!target) {
			return;
		}
		
		// Calculate the current rotation angles
		var wantedRotationAngle = target.eulerAngles.y;
		var wantedHeight = target.position.y + height;
		
		var currentRotationAngle = transform.eulerAngles.y;
		var currentHeight = transform.position.y;


		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);
		
		// Damp the height
		currentHeight = Mathf.Lerp (currentHeight, wantedHeight, heightDamping * Time.deltaTime);
		
		// Convert the angle into a rotation
		var currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);



		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		if (Cam_OnCollider) {
			if (distance < 7f)
				distance += 0.1f;
			else
				distance = 7f;
			Look.transform.position = new Vector3 (target.position.x, (target.position.y + 7.0f), target.position.z);
		} else if (!Cam_OnCollider) {
			if(distance > 5f)
				distance -= 0.1f;
			else
				distance = 5f;
			Look.transform.position = new Vector3 (target.position.x, (target.position.y + 5.0f), target.position.z);
		}

		Look.transform.position -= currentRotation * Vector3.forward * distance;
		// Set the height of the camera
		//Look.position.y = 10f;
		//currentHeight
		// Always look at the target
		transform.LookAt (target);
	}

}