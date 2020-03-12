using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryManager : MonoBehaviour
{
    [Header("Inventory")]
    public List<Item> StartingItems;
    public int maxItems;
    public List<InventorySlotController> inventorySlots;
    public GameObject inventoryUI;

    [Header("Sword Menu")]
    public List<InventorySlotController> swordSlots;
    public GameObject SwordMenuUI;

    public PlayerManager player;


    public event Action<InventorySlotController> OnLeftClickEvent;
    public event Action<InventorySlotController> OnPointerClickEvent;
    public event Action<InventorySlotController> OnPointerEnterEvent;
    public event Action<InventorySlotController> OnPointerExitEvent;
    public event Action<InventorySlotController> OnBeginDragEvent;
    public event Action<InventorySlotController> OnEndDragEvent;
    public event Action<InventorySlotController> OnDragEvent;
    public event Action<InventorySlotController> OnDropEvent;

    [Header("Debugging")]
    public Item testItem;

    private void Start()
    {
        for (int i = 0; i < inventorySlots.Count; i++)
        {
            inventorySlots[i].OnPointerEnterEvent   += OnPointerEnterEvent;
            inventorySlots[i].OnPointerExitEvent    += OnPointerExitEvent;
            inventorySlots[i].OnBeginDragEvent      += OnBeginDragEvent;
            inventorySlots[i].OnEndDragEvent        += OnEndDragEvent;
            inventorySlots[i].OnDragEvent           += OnDragEvent;
            inventorySlots[i].OnDropEvent           += OnDropEvent;
            inventorySlots[i].OnLeftClickEvent      += OnLeftClickEvent;
        }
        SetStartingItems();
    }

    void SetStartingItems()
    {
        for (int i = 0; i < StartingItems.Count; i++)
        {
            inventorySlots[i].SetSlot(StartingItems[i]);
        }
    }

    private void Update()
    {
        AddItemToInv();
    }

    void AddToList(Item newItem)
    {
        for(int i = 0; i < maxItems; i++)
        {
            if(inventorySlots[i].item == null)
            {
                inventorySlots[i].SetSlot(newItem);
                return;
            }
        }
        Debug.Log("Inventory Full");
    }

    void RemoveFromList(int index)
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (i == index && inventorySlots[i] != null)
            {
                inventorySlots[i].SetSlot(null);
                return;
            }
        }
        Debug.Log("Inventory Empty");
    }

    public bool IsFull ()
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (inventorySlots[i].item == null)
            {
                return false;
            }
        }
        return true;
    }
    
    public void AddItemToInv()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            AddToList(testItem);
        }
    }
}
