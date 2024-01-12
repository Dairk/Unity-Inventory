using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class ExampleItem : MonoBehaviour, IPickupable
{
 

    /// <summary>
    /// This is where you will want to add your own implementation for your own systems.
    /// </summary>
    public float PickUpRadius = 1f;
    public InventoryItemData ItemData;
    private SphereCollider myCollider;

    private void Awake()
    {
        myCollider = GetComponent<SphereCollider>();
        myCollider.isTrigger = true;
       // myCollider.size = PickUpRadius;


    }

    private void OnTriggerEnter(Collider other)
    {
        var inventory = other.transform.GetComponent<InventoryHolder>();
        if (!inventory) return;

        if (inventory.InventorySystem.AddToInventory(ItemData, 1))
        {
            Pickup();
        }
    }

    public void Pickup()
    {
        Destroy (this.gameObject);
        //Destroy(gameObject);

      
    }
}
