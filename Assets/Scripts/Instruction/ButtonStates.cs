using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonStates : MonoBehaviour {


    public Button walk;
    public Button jump;
    public Button dash;

    public Sprite clickedWalk;
    public Sprite notClickedWalk;
    public Sprite clickedJump;
    public Sprite notClickedJump;
    public Sprite clickedDash;
    public Sprite notClickedDash;

    public VideoInstruc mudaVideos;


    public void clickedButtonWalk()
    {
        walk.image.overrideSprite = clickedWalk;
        jump.image.overrideSprite = notClickedJump;
        dash.image.overrideSprite = notClickedDash;
        mudaVideos.changeVideoWalk();
    }

    public void clickedButtonJump()
    {
        jump.image.overrideSprite = clickedJump;
        walk.image.overrideSprite = notClickedWalk;
        dash.image.overrideSprite = notClickedDash;
        mudaVideos.changeVideoJump();

    }

    public void clickedButtonDash()
    {
        dash.image.overrideSprite = clickedDash;
        jump.image.overrideSprite = notClickedJump;
        walk.image.overrideSprite = notClickedWalk;
        mudaVideos.changeVideoDash();

    }

}
