using UnityEngine;
using System.Collections;

public class ScaleCenary_Test : MonoBehaviour
{
    //calibradores do escalonamento
    public int startSize = 3;
    public int minSize = 1;
    public int maxSize = 6;
    public float speed = 2.0f;
    public int scaleQtd;
    public AbleDisableSky changeState;

    public bool mudancaAceita;
    private Vector3 targetScale;
    private Vector3 baseScale;
    private int currScale;

    void Start()
    {
        GetComponent<Renderer>().enabled = false;
        baseScale = transform.localScale;
        transform.localScale = baseScale * startSize;
        currScale = startSize;
        targetScale = baseScale * startSize;
    }
    /*
        void OnTriggerEnter(Collider colisao)
        {
            if (colisao.gameObject.name == "player")
            {
                Debug.Log("Entrou no trigger");
                changeSize(true);

                //currScale++;

                //currScale = Mathf.Clamp(currScale, minSize, maxSize + 1);

                //targetScale = baseScale * currScale;
            }
        }


      void OnTriggerExit(){
            Debug.Log("Fora do trigger");
            changeSize(false);
        }
        */

    void Update() {
        mudancaAceita = changeState.changeSkybox;
        if (mudancaAceita)
        {
            GetComponent<Renderer>().enabled = true;
            changeSize(true);
        }   else if (!mudancaAceita) {
            //GetComponent<Renderer>().enabled = false;
            changeSize(false);
        }

        transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);       
    }

    void changeSize(bool scale) {
        if (scale) {
            currScale = currScale * scaleQtd;
            Debug.Log(currScale);
        }
        if (!scale)
        {
            currScale = currScale/ scaleQtd;
            Debug.Log(currScale);
        }
        currScale = Mathf.Clamp(currScale, minSize, maxSize + 1);
        targetScale = baseScale * currScale;
    }
}
