using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSubmit : MonoBehaviour
{
    public GameObject twodebris;
    public GameObject trigger1;
    public GameObject trigger2;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(twodebris.GetComponent<PushBoxRoomReset>().bothpicked)
        {
            Destroy(trigger1);
            trigger2.SetActive(true);
        }
    }
}
