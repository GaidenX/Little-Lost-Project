using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Animation_Script : MonoBehaviour {

	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown(KeyCode.Space)) {
			SceneManager.LoadScene ("roll a ball");
		}
	}
}
