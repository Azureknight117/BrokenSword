using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPieceManager : MonoBehaviour
{
    public SwordPiece piece;
    public SpriteRenderer spriteRenderer;
    public BoxCollider2D boxCollider;
    public int power;


    public void SetSwordPiece()
    {
        if (piece.sprite != null)
        {
            spriteRenderer.sprite = piece.sprite;
            Vector2 s = spriteRenderer.sprite.bounds.size;
            boxCollider.size = s;
            power = piece.power;
        }
        else
        {
            Debug.Log("ahh");
        }
    }

    public void EquipNewPiece(SwordPiece newPiece)
    {
        piece = newPiece;
    }


}
