﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuController : MonoBehaviour
{
    public InventoryManager inventory;
    public SwordMenuUI sword;

    public Image draggableItem;
    private InventorySlotController draggedSlot;

    private void Awake()
    {
        //inventory.OnPointerEnterEvent +=
        //inventory.OnPointerExitEvent +=
        inventory.OnBeginDragEvent += BeginDrag;
        inventory.OnEndDragEvent += EndDrag;
        inventory.OnDragEvent += Drag;
        inventory.OnDropEvent += Drop;
        //inventory.OnLeftClickEvent += OnLeftClick;
    }

    void BeginDrag(InventorySlotController itemSlot)
    {
        if(itemSlot.item != null)
        {
            draggedSlot = itemSlot;
            draggableItem.sprite = itemSlot.item.sprite;
            draggableItem.transform.position = Input.mousePosition;
            draggableItem.enabled = true;
        }
    }

    void EndDrag(InventorySlotController itemSlot)
    {
        draggedSlot = null;
        draggableItem.enabled = false;
    }

    private void Drag(InventorySlotController itemSlot)
    {
        if (draggableItem.enabled)
        {
            draggableItem.transform.position = Input.mousePosition;
        }
    }

    void Drop(InventorySlotController itemSlot)
    {
        if (itemSlot.isSwordSlot  && !(draggedSlot.item is SwordPiece))
        {

        }
        else
        {
            if (itemSlot.IsItemValid(draggedSlot.item))
            {
                Item draggedItem = draggedSlot.item;
                draggedSlot.SetSlot(itemSlot.item);
                itemSlot.SetSlot(draggedItem);
            }
        }

    }
}
