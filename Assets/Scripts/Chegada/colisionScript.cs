using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class colisionScript : MonoBehaviour {

	public Transform Portal;

	// Use this for initialization
	void OnCollisionEnter (Collision col)
	{
		//CHEGADA ------------------------------------------
		if(col.gameObject.name == "player")
		{
			SceneManager.LoadScene(4);
		}
		//FIM CHEGADA --------------------------------------
	}
	
	// Animaçao Portal ------------
	void Update () {

		Portal.transform.Rotate(0, 0,Time.deltaTime * 30);
	}
}
