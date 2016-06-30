using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class functionScript : MonoBehaviour {
	public void start_Menu () {
		SceneManager.LoadScene (0);
	}

	public void instruction () {
        SceneManager.UnloadScene(0);
        SceneManager.LoadScene (1);  
	}

	public void restart () {
		SceneManager.LoadScene (2);
	}

	public void Credits(){
		SceneManager.LoadScene (3);
	}

	public void exit ()
	{
		Application.Quit();
	}
}
