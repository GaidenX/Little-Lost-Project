using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combination : MonoBehaviour
{
    public SpriteRenderer spriteRender;

    public Sprite Direcionais;
    public Sprite Space;
    public Sprite Dash;

    // Use this for initialization

    public void CombinationWalk() {
        spriteRender.sprite = Direcionais;
    }

    public void CombinationSpace()
    {
        spriteRender.sprite = Space;
    }

    public void CombinationDash()
    {
        spriteRender.sprite = Dash;
    }
}
