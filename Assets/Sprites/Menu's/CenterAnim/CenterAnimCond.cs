using UnityEngine;
using System.Collections;

public class CenterAnimCond : MonoBehaviour {

    public Animator animCenter;
	
	// Update is called once per frame
	public void centerPlay() {
        animCenter.SetInteger("Play", 2);
	}

    public void centerPlayReverse() {
        animCenter.SetInteger("Play", 1);
    }
}
