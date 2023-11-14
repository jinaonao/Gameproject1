using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeforeCardTr : MonoBehaviour
{
    public Inventory playerInventory; // 玩家背包的引用
    public GameObject objectToRemove; // 要移除的场景对象
    public GameObject doubleDoorTriggerObject;

    void Update()
    {
        if (playerInventory.ContainsItem(4)) // 检查itemID为4的物品是否存在
        {
            // 如果存在，移除或禁用场景中的物体
            if (objectToRemove != null)
                objectToRemove.SetActive(false); // 或者使用 Destroy(objectToRemove) 完全移除
            if (doubleDoorTriggerObject != null)
            {
                DoubleDoorTrigger ddt = doubleDoorTriggerObject.GetComponent<DoubleDoorTrigger>();
                if (ddt != null)
                {
                    ddt.isEnergy = true;
                }
            }
        }
    }
}
