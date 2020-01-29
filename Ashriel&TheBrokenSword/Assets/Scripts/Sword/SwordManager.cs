using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public Transform middlePieceHolder;
    public Transform tipPieceHolder;

    [Header("SwordPieces")]
    public SwordPiece mid;
    public SwordPiece tip;

    public float hiltDamage;
    [HideInInspector]
    public float totalDamage; //Combined damage of all pieces

    private void Start()
    {
        GetTotalDamage();
    }

    float GetTotalDamage()
    {
        totalDamage = hiltDamage + mid.power + tip.power;
        return totalDamage;
    }
}
