using UnityEngine;
using System.Collections;

public class instructionInGame : MonoBehaviour {
	public GameObject game,instuction;
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			game.SetActive(true);
			instuction.SetActive(false);
		}
	}//FIM UPDATE
}
