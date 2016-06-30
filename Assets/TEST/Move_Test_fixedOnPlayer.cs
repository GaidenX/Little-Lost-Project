using UnityEngine;
using System.Collections;

public class Move_Test_fixedOnPlayer : MonoBehaviour {
	//camera move INICIO ----------------------------------------
	Vector3 offset = new Vector3(0f,1.5f,0f),targetPosition, lookDir;
	private Vector3 velocityCamSmooth = Vector3.zero;
	private Transform Follow;
	//camera move FIM ----------------------------------------
	public float DistanceAway, DistanceUp,smooth,camSmoothDampTime;
	public Vector3 ref_Target, cam_Target;
	public bool hitWall;

	// Use this for initialization
	void Start () {
		//Camera move inicio -------------------------------------
		Follow = GameObject.FindWithTag("PlayCam").transform;
		//camera move fim ----------------------------------------
	}

	// Update is called once per frame
	void LateUpdate () {
		Vector3 charOffset = Follow.position + offset;

		lookDir = charOffset - this.transform.position;
		lookDir.y = 0;
		lookDir.Normalize ();
		Debug.DrawRay(transform.position, lookDir, Color.green);

		//camera move INICIO ----------------------------------------------------------
		targetPosition = charOffset + Follow.up * DistanceUp - lookDir * DistanceAway;
		Debug.DrawRay(Follow.position, Vector3.up * DistanceUp, Color.red);
		Debug.DrawRay(Follow.position, -1f * Follow.forward * DistanceAway, Color.blue);
		Debug.DrawLine (Follow.position, targetPosition, Color.magenta);
		smoothPos(this.transform.position, targetPosition);

		//camHitWall (targetPosition, ref cam_Target);
		transform.LookAt (Follow);
		//camera move FIM -------------------------------------------------------------
	}

	private void smoothPos(Vector3 fromPos, Vector3 toPos){
		this.transform.position = Vector3.SmoothDamp (fromPos, toPos, ref velocityCamSmooth, camSmoothDampTime);
	}

	private void camHitWall(Vector3 FromObj, ref Vector3 ToTargetRef){
		//camera wall colision INICIO--------------------------------------------------
		Debug.DrawLine (FromObj, ToTargetRef, Color.red);
		RaycastHit ref_HitOnWall = new RaycastHit ();
		if (Physics.Linecast (FromObj, ToTargetRef, out ref_HitOnWall)) {
			Debug.DrawRay (ref_HitOnWall.point, Vector3.left, Color.green);
			transform.position = new Vector3 (ref_HitOnWall.point.x, transform.position.y, ref_HitOnWall.point.z);
		}
		//camera wall colision FIM--------------------------------------------------
	}
}
