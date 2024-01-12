using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChestInventory : InventoryHolder, IInteractable
{
    public UnityAction<IInteractable> OnInteractionComplete { get; set; }

    protected void Awake()
    {
        base.Awake();
        SaveLoad.OnLoadGame += LoadInventory;
    }

    private void LoadInventory(SaveData data)
    {
        //
    }
    public void Interact(Interactor interactor, out bool interactionSuccesful)
    {
        OnDynamicInventoryDisplayRequested?.Invoke(inventorySystem);
        interactionSuccesful = true;
    }

    public void EndInteraction()
    {
        
    }
}

[System.Serializable]
public struct ChestSaveData
{
    public InventorySystem invSystem;
    public Vector3 position;
    public Quaternion rotation;

    public ChestSaveData(InventorySystem _invSystem, Vector3 _position, Quaternion _rotation)
    {
        invSystem = _invSystem;
        position = _position;
        rotation = _rotation;

    }
}
