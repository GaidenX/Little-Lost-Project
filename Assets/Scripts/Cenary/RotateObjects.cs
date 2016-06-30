using UnityEngine;
using System.Collections;

public class RotateObjects : MonoBehaviour {


	// Variavel para os gameobjects
	public Transform Plano;
	public Transform Cube2;
	public Transform Colisao3;

	//---- Variaveis para iniciar funcoes ----
	public bool rodar = false;
	public bool andar = false;

	//---- Variaveis da funcao rotate() ----
	public bool rotateX = false;
	public bool rotateY = false;
	public bool rotateZ = false;
	public int forcaRotate = 30;

	//---- Variaveis da funcao move() ----
	public float movimento ;
	public float forca;
	public bool chegada1 = false;
	private float forca1 = 0.1f;

	
	// Update is called once per frame
	void Update () {
		if (rodar == true) {
		
			Rotate ();

		} else if (andar == true) {
			Move (movimento);
		}

		//Plano.transform.Rotate(0, 0, Time.deltaTime * 30);
		//Plano.transform.Rotate(0, Time.deltaTime, 0, Space.World);
	}


	void Rotate () {

		if (rotateX == true) {
			Plano.transform.Rotate (Time.deltaTime * forcaRotate, 0, 0);
		
		} else if (rotateY == true) {
			Plano.transform.Rotate (0, Time.deltaTime * forcaRotate, 0);
		
		} else if (rotateZ == true) {
			Plano.transform.Rotate (0, 0, Time.deltaTime * forcaRotate);
		}
	}



	void Move (float movimento) {
		movimento = forca1;
	
		//forca1 = Time.time * 0.1f;
		Plano.transform.Translate (0, movimento, 0);


		if (BoxCollider.Equals (Plano, Cube2)) {
			Debug.Log ("Entrou na funcao querida");
			Plano.transform.Rotate (0, 0, 180);
		}
		}

	void OnCollisionEnter (Collision colisao){

		if (colisao.gameObject.name == "Cube2") {
			Debug.Log ("Entrou na funcao");
			Plano.transform.Rotate (0,180,0);
		/*	Plano.localRotation.Set (0,0,0,0);
			Plano.eulerAngles.Set (0,0,0);
			Plano.localPosition.Set (0,0,0);
			Cube2.localPosition.Set (0,0,0);
			Cube2.eulerAngles.Set (0,0,0);
			Cube2.transform.Rotate (0,0,0); */
		}

		if (colisao.gameObject.name == "Box006"){
			Plano.transform.Rotate (0,180,0);

		}
	}


	}





