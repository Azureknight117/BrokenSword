using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordManager : MonoBehaviour
{
    public GameObject middlePieceHolder;
    public GameObject tipPieceHolder;

    [Header("SwordPieces")]
    public SwordPiece mid;
    public SwordPiece tip;

    public float hiltDamage;
    [HideInInspector]
    float totalDamage; //Combined damage of all pieces
}
