using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine.Tilemaps;
using UnityEngine;

public class PushBoxRoomReset : MonoBehaviour
{
    private Inventory inventory;
    public GameObject Reset;

    public GameObject[] objectsToReset; // 存储所有需要重置的对象
    private Vector2[] initialPositions; // 存储初始位置
    public GameObject[] pickUpobjectsToReset;

    bool ifReset = false;


    public bool bothpicked = false;
    private void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        initialPositions = new Vector2[objectsToReset.Length];
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            initialPositions[i] = objectsToReset[i].transform.position;
        }
    }
    void Update()
    {
        if (ifReset)
        {
            ResetObject();
            ifReset = false;
        }
        if (pickUpobjectsToReset[0].GetComponent<Pickup>().bepicked && pickUpobjectsToReset[1].GetComponent<Pickup>().bepicked)
        {
            bothpicked = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ifReset = true;
    }
    void ResetObject()
    {
        for (int i = 0; i < objectsToReset.Length; i++)
        {
            objectsToReset[i].transform.position = initialPositions[i];
        }

        if (bothpicked)
        {
            return;
        }
        else
        {
            for (int i = inventory.slots.Length - 1; i >= 0; i--)
            {
                Slot currentSlot = inventory.slots[i].GetComponent<Slot>();
                if (currentSlot.itemID == 1 || currentSlot.itemID == 2)
                {
                    //inventory.isFull[i] = false;
                    currentSlot.destroyItem();
                    pickUpobjectsToReset[0].GetComponent<Pickup>().bepicked = false;
                    pickUpobjectsToReset[1].GetComponent<Pickup>().bepicked = false;
                    break;
                }
            }
            for (int i = 0; i < pickUpobjectsToReset.Length; i++)
            {
                pickUpobjectsToReset[i].SetActive(true); // 重新显示这个物品
            }

        }
    }
}
