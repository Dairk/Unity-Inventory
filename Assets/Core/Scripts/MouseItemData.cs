using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
using TMPro;
using Unity.Mathematics;


public class MouseItemData : MonoBehaviour
{
    public Image ItemSprite;
    public TextMeshProUGUI ItemCount;
    public InventorySlot AssignedInventorySlot;
    public string ID => ID;
    [SerializeField]public float dropOffset;
    private Transform playerTransform;
    
    private void Awake()
    {
        ItemSprite.color = Color.clear;
        ItemCount.text = "";

        playerTransform = GameObject.FindGameObjectWithTag
            ("Player").GetComponent<Transform>();
        if(playerTransform == null) Debug.Log("player not found");
        
        
    }

    public void UpdateMouseSlot(InventorySlot invSlot)
    {
        AssignedInventorySlot.AssignItem(invSlot);
        ItemSprite.sprite = invSlot.ItemData.Icon;
        ItemCount.text = invSlot.StackSize.ToString();
        ItemSprite.color = Color.white;
    }

    private void Update()
    {
        if ( AssignedInventorySlot.ItemData != null) // If has an item, follow the mouse position.
        {
            transform.position = Mouse.current.position.ReadValue();

            if (Mouse.current.leftButton.wasPressedThisFrame && !IsPointerOverUIObject())
            {
               // if(AssignedInventorySlot.ItemData.ItemPrefab != null)Instantiate(AssignedInventorySlot.ItemData.ItemPrefab,
                //       playerTransform.position + playerTransform.forward * dropOffset,
                //       quaternion.identity);
                    
                ClearSlot();
                
            }
        }
    }

    public void ClearSlot()
    {
        AssignedInventorySlot.ClearSlot();
        ItemCount.text = "";
        ItemSprite.color = Color.clear;
        ItemSprite.sprite = null;
    }

    public static bool IsPointerOverUIObject() // From stack overflow.
    {
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        eventDataCurrentPosition.position = Mouse.current.position.ReadValue();
        List<RaycastResult> results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }
    
}
