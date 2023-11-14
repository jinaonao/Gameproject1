using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGameIntroduaction : MonoBehaviour
{
    public GameObject intro;
    public bool ifW = false;
    public bool ifA = false;
    public bool ifS = false;
    public bool ifD = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            ifW = true;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            ifA = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ifS = true;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            ifD = true;
        }
        if(ifW&& ifA&&ifS&&ifD)
        {
            Destroy(intro);
        }
    }
}
