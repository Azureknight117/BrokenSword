using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public GameObject midPiece;
    public GameObject tipPiece;
    public GameObject SwordMenu;

    public int hiltDamage;
    [HideInInspector]
    public int totalDamage; //Combined damage of all pieces

    private void Start()
    {
        GetTotalDamage();
        GetSwordPieces();
    }

    int GetTotalDamage()
    {
        totalDamage = hiltDamage + midPiece.GetComponent<SwordPieceManager>().power + tipPiece.GetComponent<SwordPieceManager>().power;
        return totalDamage;
    }

    void GetSwordPieces()
    {
        midPiece.GetComponent<SwordPieceManager>().SetSwordPiece(midPiece.GetComponent<SwordPieceManager>().piece);
        tipPiece.GetComponent<SwordPieceManager>().SetSwordPiece(tipPiece.GetComponent<SwordPieceManager>().piece);
    }

    public void SwordSwing()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        if (midPiece.GetComponent<SwordPieceManager>().piece != null)
        {
            midPiece.GetComponent<BoxCollider2D>().enabled = true;
        }
        if (tipPiece.GetComponent<SwordPieceManager>().piece != null)
        {
            tipPiece.GetComponent<BoxCollider2D>().enabled = true;
        }
    }

    public void StopSwing()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        midPiece.GetComponent<BoxCollider2D>().enabled = false;
        tipPiece.GetComponent<BoxCollider2D>().enabled = false;
    }

}
