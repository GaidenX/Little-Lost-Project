using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Menu : MonoBehaviour {
	private bool menu=false;
	public GameObject menuInt,restInt,Robo_Ref,Robo_Corpo;
	public GameObject INSTRUCTION;
	public Canvas Menu_Esc,Interface;

	// Use this for initialization
	void Awake () {
		Menu_Esc = Menu_Esc.GetComponent<Canvas> ();
		Menu_Esc.enabled = false;
		menuInt.SetActive(false);
		menu=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) && menu == false && INSTRUCTION.activeSelf == false) {
			menu = true;
			menuInt.SetActive(true);
			Menu_Esc.enabled = true;
		}
		else if (Input.GetKeyDown (KeyCode.Escape) && menu == true && INSTRUCTION.activeSelf == false){
			menu = false;
			menuInt.SetActive(false);
			Menu_Esc.enabled = false;
		}
		//Menu ESC ATIVO------------------------------------------------------------------------------------
		if (Menu_Esc.enabled == false) {
			Interface.enabled = true;
			Robo_Ref.SetActive (true);
			Robo_Corpo.SetActive (true);
		} else {
			Interface.enabled = false;
			Robo_Ref.SetActive(false);
			Robo_Corpo.SetActive(false);
		}
	//FIM Menu ESC ATIVO--------------------------------------------------------------------------------
		if(restInt.activeSelf == true){
			menuInt.SetActive(false);
			Robo_Ref.SetActive(false);
			Robo_Corpo.SetActive(false);
			Interface.enabled = false;
		}

	

	}//UPDATE

}//FIM CLASSE
