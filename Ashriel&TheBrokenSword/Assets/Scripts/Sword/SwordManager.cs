﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public GameObject midPiece;
    public GameObject tipPiece;

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
        midPiece.GetComponent<SwordPieceManager>().SetSwordPiece();
        tipPiece.GetComponent<SwordPieceManager>().SetSwordPiece();
    }

    public void SwordSwing()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = true;
        midPiece.GetComponent<BoxCollider2D>().enabled = true;
        tipPiece.GetComponent<BoxCollider2D>().enabled = true;
    }

    public void StopSwing()
    {
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        midPiece.GetComponent<BoxCollider2D>().enabled = false;
        tipPiece.GetComponent<BoxCollider2D>().enabled = false;
    }

}
