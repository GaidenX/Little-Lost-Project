using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VideoInstruc : MonoBehaviour
{

    public MovieTexture movTextureAndar;
    public MovieTexture movTextureJump;
    public MovieTexture movTextureDash;

    public Combination mudaCombinacao;

    // Use this for initialization
    void Start()
    {
        movTextureAndar.loop = true;
        movTextureJump.loop = true;
        movTextureDash.loop = true;
        GetComponent<Renderer>().material.mainTexture = movTextureAndar;
        movTextureAndar.Play();

    }

    public void changeVideoWalk() {
        GetComponent<Renderer>().material.mainTexture = movTextureAndar;
        movTextureAndar.Play();
        mudaCombinacao.CombinationWalk();
    }

    public void changeVideoJump()
    {
        GetComponent<Renderer>().material.mainTexture = movTextureJump;
        movTextureJump.Play();
        mudaCombinacao.CombinationSpace();
    }

    public void changeVideoDash()
    {
        GetComponent<Renderer>().material.mainTexture = movTextureDash;
        movTextureDash.Play();
        mudaCombinacao.CombinationDash();
    }
}