using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Move_Test : MonoBehaviour {
	//AUDIO **********************************************
	public SFX sfx;
	//**********************************************
	/* ---------PUBLICAS------------ */
	// INTERFACE SCRIPT ASSOSSIATION.
	public Canvas Interface;
	public Slider Fuel;
	public Text int_timer,txt_energy,txt_death,txt_noTime;
	float int_timer_min, int_timer_sec;
	//------------------------------
	public float horizontalSpeed = 0.0F;
	public float verticalSpeed = 0.0F;
	public float puloSpeed = 25.0F;
	public float speed = 0.0F;
	public bool pular1 = false, pular2 = false, Dash=false;
	public Transform Person, Pivot,Robot;//pegar posiçao do objeto, usado na animaçao tambem
	float moveZ, angX, timer;
	public int puloCont = 0;

	public GameObject Menu_Morte,Robo_Corpo,Robo_Ref;
	/* --------PRIVATES-------------*/

	//ACELERAÇAO = A= Vel/Tempo	
	private Rigidbody rb;

	void Start () {
		int_timer_min = 2f; int_timer_sec = 00f; // TEMPO DE JOGO

		//*******************************************************
		txt_energy.enabled = false;
		txt_death.enabled = false;
		txt_noTime.enabled = false;

		txt_energy.gameObject.SetActive(false);
		txt_death.gameObject.SetActive(false);
		txt_noTime.gameObject.SetActive(false);

		//*******************************************************

		Menu_Morte.SetActive (false);
		rb = GetComponent<Rigidbody>();
		Person = GetComponent<Transform> ();
		Robot.transform.eulerAngles = new Vector3(0f,90f,359f);

	}

	// Update is called once per frame
	void Update () {
		//TEMPO DE JOGO-------------------------------------------------------------------------------------
		if (int_timer_sec <= 00f && int_timer_min >= 0f) {
			int_timer_min -= 1f; int_timer_sec = 59f;
		}
		if(int_timer_sec < 10f && int_timer_min >=0f)
			int_timer.text = "0" + (int)int_timer_min + ":" + "0" + (int)int_timer_sec;
		else if(int_timer_sec >= 10f && int_timer_min >=0f)
			int_timer.text = "0" + (int)int_timer_min + ":" + (int)int_timer_sec;

		int_timer_sec -= Time.deltaTime*2;// DIMINUIÇAO DO TEMPO.

		// TEMPO ESGOTADO-------------------------------------------------------------

	/*	if (int_timer_min <= 0f && int_timer_sec <= 0f) {
			txt_noTime.enabled = true;
			txt_noTime.gameObject.SetActive(true);
			Menu_Morte.SetActive (true);
			Robo_Corpo.SetActive (false);
			Robo_Ref.SetActive (false);
			Interface.enabled = false;
		}//FIM TEMPO ESGOTADO-------------------------------------------------------------
	*/
		//SEM ENERGIA------------------------------------------------------------------------
		/*if (Fuel.value <= 0f) {
			txt_energy.enabled = true;
			txt_energy.gameObject.SetActive(true);
			Menu_Morte.SetActive (true);
			Robo_Corpo.SetActive (false);
			Robo_Ref.SetActive (false);
			Interface.enabled = false;
		}*/
		//FIM SEM ENERGIA--------------------------------------------------------------------

		//FIM TEMPO DE JOGO---------------------------------------------------------------------------------
		//MOVEMENT------------------------------------------------------------------------------------------
		horizontalSpeed = Input.GetAxis("Horizontal");
		verticalSpeed = Input.GetAxis ("Vertical");
		speed = new Vector2(horizontalSpeed,verticalSpeed).sqrMagnitude;

		if (rb.velocity.z >= 10f)
			rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,10f);
		if (rb.velocity.z <= -10f)
			rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,-10f);
		if (rb.velocity.x >= 10f)
			rb.velocity = new Vector3(10f,rb.velocity.y,rb.velocity.z);
		if (rb.velocity.x <= -10f)
			rb.velocity = new Vector3(-10f,rb.velocity.y,rb.velocity.z);
		
		if (verticalSpeed > 0.25f && rb.velocity.z <= 10f) {
				rb.AddForce (Person.transform.forward * (speed / Time.deltaTime), ForceMode.Acceleration);
		}
		if (verticalSpeed < -0.25f && rb.velocity.z >= -10f){
				rb.AddForce (-Person.transform.forward * (speed / Time.deltaTime), ForceMode.Acceleration);
		}

		/*if (Input.GetKey (KeyCode.UpArrow) || Input.GetKey (KeyCode.W) && !Dash && !pular1) {
			rb.AddForce(Person.transform.forward * ( speed/Time.deltaTime),ForceMode.Acceleration);
			Fuel.value -= Time.deltaTime * 10F;

			if(Robot.transform.eulerAngles.z <= 360f && Robot.transform.eulerAngles.z >= 345f && !Dash && !pular1){
				Robot.transform.eulerAngles -= new Vector3(0f,0f,1f);
			}
		}
		if (Input.GetKey (KeyCode.DownArrow) || Input.GetKey (KeyCode.S) && !Dash && !pular1) {
			rb.AddForce (-Person.transform.forward * (speed / Time.deltaTime),ForceMode.Acceleration);
			Fuel.value -= Time.deltaTime * 10F;

			if(Robot.transform.eulerAngles.z <= 358f && Robot.transform.eulerAngles.z >= 320f && !Dash && !pular1){
				Robot.transform.eulerAngles += new Vector3(0f,0f,1f);
			}
		}*/
		//FIM MOVEMENT--------------------------------------------------------------------------------------
		//PULO----------------------------------------------------------------------------------------------
		if (Input.GetKeyDown (KeyCode.Space) && pular1 == false && puloCont == 0){
			pular1 = true;
			puloCont = 1;

		}

		if (pular1 == true && puloCont == 1) {
			rb.AddForce (Person.transform.up * puloSpeed,ForceMode.Impulse);
			pular1 = false;
		} 
		//FIM PULO-------------------------------------------------------------------------------------------
		//GRAVITY--------------------------------
		rb.AddForce (Person.transform.up * -50f,ForceMode.Force);
		//END GRAVITY----------------------------
		//DASH------------------------------------------------------------------------------------------
		if (Input.GetKeyDown(KeyCode.LeftShift) && pular1 == false && puloCont == 1)
		{
			pular2 = true;
			puloCont = 2;
			Dash = true;
		}

		if(pular2 == true && puloCont == 2)
		{
			Fuel.value -= 12f;// CUSTO DASH NA ENERGIA--------------------------------------------------
			timer = 0.35f;
			rb.constraints = RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionY;
			rb.AddForce(Person.transform.forward * 1.5f,ForceMode.Impulse);
			pular2 = false;
		}
		if (timer >= 0f)
			timer = timer - Time.deltaTime;
		if (timer <= 0.00000f) {
			rb.constraints = RigidbodyConstraints.None;
			Dash = false;
		}
		Person.transform.eulerAngles = Pivot.transform.eulerAngles;
		//FIM DASH------------------------------------------------------------------------------------------

		//CODICAO DE MORTE----------------------------------------------------------------------------------
		if (Person.position.y < -45.5f || Robot.position.y < -45.5f) {
			sfx.Death_Sound_Effect();
			txt_death.enabled = true;
			txt_death.gameObject.SetActive(true);
			Menu_Morte.SetActive(true);
			Robo_Corpo.SetActive(false);
			Robo_Ref.SetActive(false);
		}
		//FIM CODICAO DE MORTE------------------------------------------------------------------------------
	}//Fim Update

	void OnCollisionEnter (Collision col)
	{
		//if(col.gameObject.name == "Terreno")
		//{
		//GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
		if (col.gameObject.tag == "Coletavel") {
			sfx.Energy();
			col.gameObject.SetActive (false);
			Fuel.value += 20f;
		}

		if (col.gameObject && Person.transform.localPosition.y >= 1f)
		{
			pular1 = false;
			puloCont = 3;
		}
		else if(col.gameObject){ 
			pular1 = false;
			puloCont = 0;
		}
		//}
	}//fim colision with.

}
