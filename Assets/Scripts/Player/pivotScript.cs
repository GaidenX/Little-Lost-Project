using UnityEngine;
using System.Collections;

public class pivotScript : MonoBehaviour {
    Transform _pivotPos;
    public GameObject _esferaPos;
    float _roboAng;

	// Use this for initialization
	void Awake () {
        _pivotPos = GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
        _roboAng += Input.GetAxis("Horizontal");
      //  _roboAng2 += Input.GetAxis("Vertical");
        _pivotPos.transform.position = _esferaPos.transform.localPosition;
        _pivotPos.transform.eulerAngles = new Vector3(0, _roboAng, 0);
	}
}
