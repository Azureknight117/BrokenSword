using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordMenuUI : MonoBehaviour
{
    public List<InventorySlotController> SwordPieces;
    int maxItems = 2;
    public SwordManager sword;

    public event Action<InventorySlotController> OnLeftClickEvent;
    public event Action<InventorySlotController> OnPointerClickEvent;
    public event Action<InventorySlotController> OnPointerEnterEvent;
    public event Action<InventorySlotController> OnPointerExitEvent;
    public event Action<InventorySlotController> OnBeginDragEvent;
    public event Action<InventorySlotController> OnEndDragEvent;
    public event Action<InventorySlotController> OnDragEvent;
    public event Action<InventorySlotController> OnDropEvent;

    private void Start()
    {
        for (int i = 0; i < SwordPieces.Count; i++)
        {
            SwordPieces[i].OnPointerEnterEvent += OnPointerEnterEvent;
            SwordPieces[i].OnPointerExitEvent += OnPointerExitEvent;
            SwordPieces[i].OnBeginDragEvent += OnBeginDragEvent;
            SwordPieces[i].OnEndDragEvent += OnEndDragEvent;
            SwordPieces[i].OnDragEvent += OnDragEvent;
            SwordPieces[i].OnDropEvent += OnDropEvent;
            SwordPieces[i].OnLeftClickEvent += OnLeftClickEvent;
        }
    }

    
    void AddToList(Item newItem)
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (SwordPieces[i].item == null)
            {
                SwordPieces[i].SetSlot(newItem);
                return;
            }
        }
        Debug.Log("Inventory Full");
    }

    void RemoveFromList(int index)
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (i == index && SwordPieces[i] != null)
            {
                SwordPieces[i].SetSlot(null);
                return;
            }
        }
        Debug.Log("Inventory Empty");
    }

    void UpdateSword()
    {
        if(SwordPieces[0] != null && SwordPieces[1] != null)
        {
            SwordPiece newPiece = SwordPieces[0].item as SwordPiece;
            sword.tipPiece.GetComponent<SwordPieceManager>().SetSwordPiece(newPiece);
        }
        if(SwordPieces[1] != null)
        {
            SwordPiece newPiece = SwordPieces[1].item as SwordPiece;
            sword.midPiece.GetComponent<SwordPieceManager>().SetSwordPiece(newPiece);
        }
    }

    public bool IsFull()
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (SwordPieces[i].item == null)
            {
                return false;
            }
        }
        return true;
    }
}
