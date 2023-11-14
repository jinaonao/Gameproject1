using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class Inventory : MonoBehaviour
{
    public bool[] isFull;
    public GameObject[] slots;
    public bool ContainsItem(int itemId)
    {
        foreach (var slot in slots)
        {
            Slot slotScript = slot.GetComponent<Slot>();
            if (slotScript != null && slotScript.itemID == itemId)
            {
                return true;
            }
        }
        return false;
    }
}
