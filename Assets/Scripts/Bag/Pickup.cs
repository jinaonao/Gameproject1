using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Pickup : MonoBehaviour
{
    private Inventory inventory;
    public GameObject itemImage;
    public GameObject gameobject;
    public bool bepicked = false;
    public int itemID;
    private void Start()
    {
        if (this.gameObject.name == "DebrisPickupLeft")
        {
            itemID = 1; 
        }
        if (this.gameObject.name == "DebrisPickupRight")
        {
            itemID = 2;
        }
        if (this.gameObject.name == "Diary")
        {
            itemID = 3;
        }
        if (this.gameObject.name == "Card")
        {
            itemID = 4;
        }
        if (this.gameObject.name == "Paper")
        {
            itemID = 5;
        }
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            for (int i = 0; i < inventory.slots.Length; i++)
            {
                if (inventory.isFull[i] == false)
                {
                    inventory.isFull[i] = true;
                    Instantiate(itemImage, inventory.slots[i].transform, false);
                    inventory.slots[i].GetComponent<Slot>().itemID = itemID;
                    this.gameObject.SetActive(false); // 隐藏这个物品
                    bepicked = true;
                    break;
                }
            }
        }
    }
}
