using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClosePuzzle : MonoBehaviour
{
    public void OnCloseButton()
    {
        gameObject.SetActive(false);
        //Time.timeScale = 1;
    }
}
