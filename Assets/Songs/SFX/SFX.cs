using UnityEngine;
using System.Collections;

public class SFX : MonoBehaviour {
	public AudioSource Sons;
	public AudioClip onButton, Death_Song, Coletavel,Robot_Anim_1;

	public void play_Button_Sound_Effect () {
		Sons.PlayOneShot (onButton, 0.5f);
	}

	public void Death_Sound_Effect () {
		Sons.PlayOneShot (Death_Song, 0.1f);
	}

	public void Energy (){
		Sons.PlayOneShot (Coletavel, 1f);
	}

	public void Game_Starting (){
		Sons.PlayOneShot (Robot_Anim_1, 1f);
	}
}
