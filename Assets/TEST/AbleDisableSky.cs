using UnityEngine;
using System.Collections;

public class AbleDisableSky : MonoBehaviour {

    public bool changeSkybox;

    void OnTriggerEnter(Collider colisao)
    {
        if (colisao.gameObject.name == "player")
        {
            Debug.Log("Entrou no trigger");
            changeSkybox = true;
           // changeSize(true);
        }
    }


    void OnTriggerExit()
    {
        changeSkybox = false;
        Debug.Log("Fora do trigger");
       // changeSize(false);
    }

}
