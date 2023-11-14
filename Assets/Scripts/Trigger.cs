using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject panel;
    public bool ifinzone = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && ifinzone)
        {
            panel.SetActive(true);
        }
        if(!ifinzone)
        {
            panel.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ifinzone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        ifinzone = false;
    }
}
