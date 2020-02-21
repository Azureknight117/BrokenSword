using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        RectTransform itemPanel = transform as RectTransform;

        if(!RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
        {
            Debug.Log("Dropped Item");
        }
    }

}
