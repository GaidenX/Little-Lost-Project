using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startScript : MonoBehaviour {

	private int contador = 0;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;

	SpriteRenderer spriteTexture;

	private AudioSource Sons;

	public AudioClip musica1;

	void Start(){
		spriteTexture = GetComponent<SpriteRenderer>();
		Sons = GetComponent<AudioSource> ();

	}

	void OnMouseDown () {
		spriteTexture.sprite = sprite3;
		SceneManager.LoadScene ("Instruction");
	}
	void OnMouseOver(){
		spriteTexture.sprite = sprite2;
		if (contador == 0) {
			Sons.PlayOneShot (musica1, 0.7f);
		}
		contador = 1;

	}
	void OnMouseExit(){

		contador = 0;
		spriteTexture.sprite = sprite1;
	}
}
