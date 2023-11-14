using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyDoubleDoorTrigger : MonoBehaviour
{
    public GameObject doubleDoorTriggerObject;
    void Update()
    {
        if (doubleDoorTriggerObject != null)
        {
            DoubleDoorTrigger ddt = doubleDoorTriggerObject.GetComponent<DoubleDoorTrigger>();
            if (ddt.isEnergy)
            {
                Destroy(gameObject);
            }
        }
    }
}
