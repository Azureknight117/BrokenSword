using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public List<Item> listOfItems;
    public int maxItems;
    public List<Button> inventorySlots;

    public GameObject inventoryUI;
    public PlayerManager player;
    public bool menuUp = false;

    [Header("Debugging")]
    public Item testItem;

    private void Start()
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (listOfItems.Count > i)
            {
                continue;
            }
            listOfItems.Add(null);
        }
        UpdateInventorySlots();
    }

    private void Update()
    {
        OpenMenu();
        AddItemToInv();
    }

    void AddToList(Item newItem)
    {
        for(int i = 0; i < maxItems; i++)
        {
            if(listOfItems[i] == null)
            {
                listOfItems[i] = newItem;
                UpdateInventorySlots();
                return;
            }
        }
        Debug.Log("Inventory Full");
    }

    void RemoveFromList(int index)
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (i == index && listOfItems[i] != null)
            {
                listOfItems[i] = null;
                UpdateInventorySlots();
                return;
            }
        }
        Debug.Log("Inventory Empty");
    }

    public void UpdateInventorySlots()
    {
        for (int i = 0; i < maxItems; i++)
        {
            inventorySlots[i].GetComponent<InventorySlotController>().SetSlot(listOfItems[i]);
        }
    }

    void OpenMenu ()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (!menuUp)
            {
                inventoryUI.SetActive(true);
                player.PauseGame();
                menuUp = true;
            }
            else
            {
                inventoryUI.SetActive(false);
                player.PauseGame();
                menuUp = false;
            }
        }
    }

    public bool IsFull ()
    {
        for (int i = 0; i < maxItems; i++)
        {
            if (listOfItems[i] == null)
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
