using UnityEngine;
using System.Collections;

public class luzScript : MonoBehaviour {
	public Transform Luz;
	public float var1,var2;
	bool cont = false;
	
	// Update is called once per frame
	void Update () {
		if (Luz.transform.position.x <= var1 && cont == false)
			cont = true;
		else if (Luz.transform.position.x >= var2 && cont == true)
			cont = false;

		if (cont == true)
			Luz.transform.position += new Vector3 ((1f * Time.deltaTime * 1.5f), 0f, 0f);
		else
			Luz.transform.position += new Vector3 ((-1f * Time.deltaTime * 1.5f), 0f, 0f);
	}
}
