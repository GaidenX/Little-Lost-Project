using UnityEngine;
using System.Collections;

public class plataformaScript : MonoBehaviour {
	public Transform Plat;
	bool cond = true;

	void Update(){
		if (cond == true)
			Plat.transform.position += new Vector3 (0f,0f, (1f * Time.deltaTime * 2));
		else
			Plat.transform.position -= new Vector3 (0f,0f,(1f * Time.deltaTime * 2));
	}
	void OnTriggerEnter(Collider other) {
		cond = !cond;
	}
}
