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


    public void SetSwordPiece()
    {
        if (piece != null)
        {
            spriteRenderer.sprite = piece.sprite;
            Vector2 s = spriteRenderer.sprite.bounds.size;
            boxCollider.enabled = true;
            boxCollider.size = s;
            power = piece.power;
        }
        else
        {
            boxCollider.enabled = false;
        }
    }

    public void EquipNewPiece(SwordPiece newPiece)
    {
        piece = newPiece;
    }


}
