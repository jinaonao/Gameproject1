using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBeforeCardTr : MonoBehaviour
{
    public Inventory playerInventory; // ��ұ���������
    public GameObject objectToRemove; // Ҫ�Ƴ��ĳ�������
    public GameObject doubleDoorTriggerObject;

    void Update()
    {
        if (playerInventory.ContainsItem(4)) // ���itemIDΪ4����Ʒ�Ƿ����
        {
            // ������ڣ��Ƴ�����ó����е�����
            if (objectToRemove != null)
                objectToRemove.SetActive(false); // ����ʹ�� Destroy(objectToRemove) ��ȫ�Ƴ�
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
