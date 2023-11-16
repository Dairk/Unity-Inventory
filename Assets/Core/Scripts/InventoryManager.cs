using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class InventoryManager : MonoBehaviour
{
    public GameObject InventoryMenu;
    public bool menuActivated;
    //public bool inventory;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Inventory") && menuActivated)
      
        {
            Time.timeScale = 1;
            InventoryMenu.SetActive(false);
            menuActivated = false;

        }
        else if (Input.GetButtonDown("Inventory") && !menuActivated)
       
        {
            Time.timeScale = 0;
            InventoryMenu.SetActive(true);
            menuActivated = true;
        }
    }
    public void AddItem(string itemName, int quantity, Texture2D itemIcon)
    {
        Debug.Log("itemName =" + itemName + "quantity =" + quantity + "itemIcon =" + itemIcon);
    }

}
