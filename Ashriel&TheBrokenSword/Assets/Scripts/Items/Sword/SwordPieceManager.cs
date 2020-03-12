using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPieceManager : MonoBehaviour
{
    public SwordPiece piece;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public bool swordDisabled = true;
    public int power;


    public void SetSwordPiece(SwordPiece p)
    {
        if (p != null)
        {
            piece = p;
            spriteRenderer.sprite = p.sprite;
            Vector2 s = spriteRenderer.sprite.bounds.size;
            boxCollider.enabled = true;
            boxCollider.size = s;
            power = p.power;
        }
        else
        {
            piece = null;
            spriteRenderer.sprite = null;
            boxCollider.enabled = false;
            power = 0;

        }
    }

    public void EquipNewPiece(SwordPiece newPiece)
    {
        piece = newPiece;
    }


}
