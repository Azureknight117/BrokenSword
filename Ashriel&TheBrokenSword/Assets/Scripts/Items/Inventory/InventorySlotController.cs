using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotController : MonoBehaviour , IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler, IBeginDragHandler, IEndDragHandler, IDragHandler, IDropHandler 
{
    public Item item;
    public Image image;
    public event Action<InventorySlotController> OnLeftClickEvent;
    public event Action<InventorySlotController> OnPointerClickEvent;
    public event Action<InventorySlotController> OnPointerEnterEvent;
    public event Action<InventorySlotController> OnPointerExitEvent;
    public event Action<InventorySlotController> OnBeginDragEvent;
    public event Action<InventorySlotController> OnEndDragEvent;
    public event Action<InventorySlotController> OnDragEvent;
    public event Action<InventorySlotController> OnDropEvent;

    public bool isSwordSlot;

    private void Start()
    {
        SetSlot(item);
    }

    public void Use()
    {
        Debug.Log("ITEM!!!");
    }

    public void SetSlot(Item newItem)
    {
        if (newItem != null)
        {
            item = newItem;
            image.sprite = newItem.sprite;
            image.color = Color.white;
        }
        else
        {
            item = null;
            image.sprite = null;
            image.color = Color.clear;
        }
    }

    public bool IsItemValid(Item item)
    {
        if(!isSwordSlot)
        {
            return true;
        }
        else
        {
            SwordPiece piece = item as SwordPiece;
            SwordMenuUI pieceList = GameObject.Find("Sword").GetComponent<SwordMenuUI>();

            if(pieceList.SwordPieces[0] == this)
            {
                if(piece.type == SwordPiece.PieceType.tip && pieceList.SwordPieces[1].item != null)
                {
                    return true;
                }
            }
            else if(pieceList.SwordPieces[1] == this)
            {
                if (piece.type == SwordPiece.PieceType.mid)
                {
                    return true;
                }
            }
        }
        return false;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData != null && eventData.button == PointerEventData.InputButton.Left)
        {
            OnLeftClickEvent?.Invoke(this);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke(this);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        OnPointerEnterEvent?.Invoke(this);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        OnBeginDragEvent?.Invoke(this);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        OnEndDragEvent?.Invoke(this);
    }

    public void OnDrag(PointerEventData eventData)
    {
        OnDragEvent?.Invoke(this);
    }

    public void OnDrop(PointerEventData eventData)
    {
        OnDropEvent?.Invoke(this);
    }
}
