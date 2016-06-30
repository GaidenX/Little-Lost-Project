using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class fonteScript : MonoBehaviour {
//	public Button Play_Button;
	public Text Play_Text;
	public Color Enter, Over, Exit, Click;

	public void Mouse_Enter () {
		//Play_Text.color = new Color(0F, 255F, 0F);
		Play_Text.color = Enter;
	}

	public void Mouse_Over () {
		//Play_Text.color = new Color(255F, 164F, 0F);
		Play_Text.color = Over;
	}

	public void Mouse_Exit  () {
		//Play_Text.color = new Color(255F, 0F, 0F);
		Play_Text.color = Exit;
	}

	public void Mouse_Click  () {
		//Play_Text.color = new Color(255F, 0F, 0F);
		Play_Text.color = Click;
	}
}
