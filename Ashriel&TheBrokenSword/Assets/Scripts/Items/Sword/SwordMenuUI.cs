using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SwordMenuUI : MonoBehaviour
{
    public List<InventorySlotController> SwordPieces;
    int maxSwordPieces = 2;

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
        
    }
}
