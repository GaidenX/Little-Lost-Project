using UnityEngine;
using System.Collections;

public class AttachObject : MonoBehaviour {

	public Transform robo;
	public Transform esfera;
	Vector3 pos;
	public Quaternion angle;
	float ang;
	float posicaoEsfera;
	float balanco;


	// Update is called once per frame
	void Update () {
		pos = new Vector3((esfera.position.x -0.47f),(esfera.position.y -0.35F),(esfera.position.z -0.04f));
		//angle = Quaternion.Euler(new Vector3(0,esfera.rotation.y,0));
		ang += Input.GetAxis("Horizontal");
		
		posicaoEsfera = esfera.localPosition.x;

		// Descobri pra ele fica balançando que nem boneco de olinda =D
		//balanco = esfera.localEulerAngles.x - 3;

		robo.transform.position = pos;
		//robo.transform.eulerAngles = new Vector3(0,esfera.eulerAngles.y,0); OU 
		robo.transform.localEulerAngles = new Vector3(posicaoEsfera,ang,0);
		//Quaternion.Slerp(robo.transform.rotation, angle, Time.deltaTime);


		// Posiçao relativa do robo para rotacionar com a esfera (porem leva em conta o centro do plano)

	/*	Vector3 PosicaoRelativa = esfera.position + transform.position;
		transform.rotation = Quaternion.LookRotation(PosicaoRelativa);
		*/


		}//FIM DO UPDATE
	}

