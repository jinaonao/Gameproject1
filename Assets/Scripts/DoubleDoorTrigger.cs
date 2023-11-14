using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class DoubleDoorTrigger : MonoBehaviour
{
    public GameObject doubleDoor0;
    public GameObject doubleDoor1;
    public bool isEnergy = false;
    bool isOpen = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isEnergy)
        {
            if (!isOpen)
            {
                doubleDoor0.GetComponent<OpenDoubleDoor>().animator.SetTrigger("Open");
                doubleDoor1.GetComponent<OpenDoubleDoor>().animator.SetTrigger("Open");
                isOpen = true;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isOpen)
        {
            doubleDoor0.GetComponent<OpenDoubleDoor>().animator.SetTrigger("Close");
            doubleDoor1.GetComponent<OpenDoubleDoor>().animator.SetTrigger("Close");
            isOpen = false;
        }
    }
}
