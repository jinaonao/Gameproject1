using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBigSlime : MonoBehaviour
{
    public GameObject panel;
    public GameObject panelbutton;
    public GameObject paneltext;

    public bool isDone = false;
    private bool isinZone = false;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDone && isinZone)
        {
            panel.SetActive(true);
            panelbutton.SetActive(true);
            paneltext.SetActive(true);
        }
        if (!isinZone)
        {
            panel.SetActive(false);
            panelbutton.SetActive(false);
            paneltext.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isinZone = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isinZone = false;
    }

}
