﻿using UnityEngine;
using System.Collections;

public class MoveScript : MonoBehaviour {
	public Transform target; 
	// Update is called once per frame
	void Update () {
		transform.position = new Vector3(target.position.x,target.position.y,target.position.z);	
	}
}
