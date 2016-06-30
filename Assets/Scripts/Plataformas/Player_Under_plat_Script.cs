using UnityEngine;
using System.Collections;

public class Player_Under_plat_Script : MonoBehaviour {
	public Transform Player,Pivot;
	public PlatScript Plataforma;
	bool cont1;

	void Update(){
		if (cont1 == true) {
			if(Plataforma.cont == true){
				Player.transform.position += new Vector3(0f,0f,(1f * Time.deltaTime * 4f));
				Pivot.transform.position += new Vector3(0f,0f,(1f * Time.deltaTime * 4f));
			}
			else{
				Player.transform.position -= new Vector3(0f,0f,(1f * Time.deltaTime * 4f));
				Pivot.transform.position -= new Vector3(0f,0f,(1f * Time.deltaTime * 4f));
			}
		}
	}

	void OnCollisionEnter(Collision collision) {
		if (collision.gameObject.name == "player") {
			cont1 = true;
		}
	}

	void OnCollisionExit(Collision collision) {
		if (collision.gameObject.name == "player") {
			cont1 = false;
		}
	}
}