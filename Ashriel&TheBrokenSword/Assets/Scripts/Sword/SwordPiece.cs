using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SwordPiece", menuName = "SwordPiece")]
public class SwordPiece : ScriptableObject
{
    public enum PieceType //Three types of sword pieces, a tip, mid, and full (a mid and a tip combined)
    {
        mid,
        tip,
        full     
    }

    public enum RarityType //common is dropped by enemies, rare is occasionally dropped by enemy or found in chests, legend types can only be found in treasure chests or from bosses
    {
        common,
        rare,
        legend
    }

    public PieceType type;
    public RarityType rarity;

    public string pieceName;
    public string description;
    public float power;//amount of damage it does, each piece has its own.
    public int length;//how long the piece is
    //higher length should mean less damage and vice versa
    public Sprite sprite;

}
