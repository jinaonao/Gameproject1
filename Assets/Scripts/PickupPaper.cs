using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPaper : MonoBehaviour
{
    public GameObject table1;
    public GameObject table2;
    public GameObject paper;
    public bool isFinding = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if (isFinding)
            {
                Destroy(table1);
                table2.SetActive(true);
                paper.SetActive(true);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isFinding = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isFinding = false;
    }
}
