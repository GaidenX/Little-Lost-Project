using UnityEngine;
using System.Collections;

public class MovimentoJogador : MonoBehaviour {
	/* ---------PUBLICAS------------ */
	
	public float horizontalSpeed = 2.0F;
	public float verticalSpeed = 2.0F;
	public float puloSpeed = 0.0F;
	private float speed = 0.5F;
	public bool pularOn = false;
	public Transform Person, Pivot;//pegar posiçao do objeto

	public float moveZ,angX;
	int puloCont = 1;
	/* --------PRIVATES-------------*/

	//ACELERAÇAO = A= Vel/Tempo
	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody>();
		Person = GetComponent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
			rb.AddForce(Person.transform.forward * ( speed/Time.deltaTime));
		if(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
			rb.AddForce(-Person.transform.forward * ( speed/Time.deltaTime));
		
		if (Input.GetKeyDown (KeyCode.Space) && pularOn == false && puloCont == 1){
			pularOn = true;
		}
		if((Input.GetKeyDown (KeyCode.Space) && pularOn == true && puloCont == 2)){
			rb.AddForce(Person.transform.forward * 1000f);
		}
		if (pularOn == true && Person.position.y < 2f && puloCont == 1) {
			rb.AddForce (Person.transform.up * 1000f);
		} else if (Person.transform.position.y >= 0f) {
			rb.AddForce (Person.transform.up * -50f);
		}
		if (Person.position.y < 0.5f && pularOn == true) {//Mudar mais pra frente para resetar com colisao com o solo.
			pularOn = false;
			puloCont = 0;
		}

		Person.transform.eulerAngles = Pivot.transform.eulerAngles;

	}//Fim Update

	void OnCollisionEnter (Collision other)
	{
		if (other.gameObject.tag == "Coletavel") {
			other.gameObject.SetActive (false);
		}
		pularOn = false;
		puloCont = 1;
		//}
	}//fim colision with.
}
