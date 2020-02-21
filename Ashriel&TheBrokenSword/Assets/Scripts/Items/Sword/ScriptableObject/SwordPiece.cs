using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New SwordPiece", menuName = "SwordPiece")]
public class SwordPiece : Item
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

    public enum Size // thick is higher damage but shorter, thin is has longer reach but less damage, balanced is a middle
    {
        thick,
        balanced,
        thin
    }

    public PieceType type;
    public RarityType rarity;
    public Size size;

    public string description;
    public int power;//amount of damage it does, each piece has its own.

}
