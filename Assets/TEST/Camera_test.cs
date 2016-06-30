using UnityEngine;
using System.Collections;

public class Camera_test : MonoBehaviour {
	//camera move INICIO ----------------------------------------
	Vector3 offset = new Vector3(0f,2f,0f),targetPosition, lookDir;
	private Transform Follow;
	//camera move FIM ----------------------------------------
	public float DistanceAway, DistanceUp,smooth,offsetY;

	// Use this for initialization
	void Start () {
		//Camera move inicio -------------------------------------
		Follow = GameObject.FindWithTag("PlayCam").transform;
		//camera move fim ----------------------------------------
	}
	
	// Update is called once per frame
	void LateUpdate () {
		Vector3 charOffset = new Vector3(Follow.position.x, Follow.position.y + offsetY, Follow.position.z) + offset;

		/*lookDir = charOffset - transform.position;
		lookDir.y = 0;
		lookDir.Normalize ();
		Debug.DrawRay(transform.position, lookDir, Color.green);*/

		//camera move INICIO ----------------------------------------------------------
		targetPosition = charOffset + Follow.up * DistanceUp - Follow.forward * DistanceAway;
		Debug.DrawRay(Follow.position, Vector3.up * DistanceUp, Color.green);
		Debug.DrawRay(Follow.position, -1f * Follow.forward * DistanceAway, Color.red);
		Debug.DrawLine (Follow.position, targetPosition, Color.magenta);

        
        camHitWall(charOffset, ref targetPosition);
        smoothPos(transform.position, targetPosition);
        transform.LookAt(Follow);

        //camera move FIM -------------------------------------------------------------
    }

	private void smoothPos(Vector3 fromPos, Vector3 toPos){
		transform.position = Vector3.Lerp (fromPos, toPos, Time.deltaTime * smooth);
	}

	private void camHitWall(Vector3 FromObj, ref Vector3 ToTargetRef){
		//camera wall colision INICIO--------------------------------------------------
		Debug.DrawLine (FromObj, ToTargetRef, Color.blue);
		RaycastHit ref_HitOnWall = new RaycastHit ();
		if (Physics.Linecast (FromObj, ToTargetRef, out ref_HitOnWall)) {
			Debug.DrawRay (ref_HitOnWall.point, Vector3.left, Color.yellow);
			ToTargetRef = new Vector3 (ref_HitOnWall.point.x, transform.position.y, ref_HitOnWall.point.z);
		}

		//camera wall colision FIM--------------------------------------------------
	}
}
