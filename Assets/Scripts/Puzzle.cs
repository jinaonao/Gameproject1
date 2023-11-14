using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Puzzle : MonoBehaviour
{
    public GameObject sign;
    public bool canPuzzle;
    public bool isDone = false;

    void Start()
    {
        canPuzzle = false;
    }

    void Update()
    {
        Highlight();
    }
    private void Highlight()
    {
        if (canPuzzle)
        {
            sign.SetActive(true);
        }
        else { sign.SetActive(false); }
    }
}
