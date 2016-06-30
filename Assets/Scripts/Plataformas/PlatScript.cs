using UnityEngine;
using System.Collections;

public class PlatScript : MonoBehaviour {
	public Transform Luz;
	public float var1,var2;
	public bool cont = false;
	
	// Update is called once per frame
	void Update () {
		if (Luz.transform.position.z <= var1 && cont == false)
			cont = true;
		if (Luz.transform.position.z >= var2 && cont == true)
			cont = false;

		if (cont == true)
			Luz.transform.position += new Vector3 (0f, 0f, (1f * Time.deltaTime * 4f));
		else
			Luz.transform.position -= new Vector3 (0f, 0f, (1f * Time.deltaTime * 4f));
	}
}
