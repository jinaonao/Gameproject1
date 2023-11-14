using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerComputer : MonoBehaviour
{
    public GameObject computer;
    public GameObject comppuzzlepanel;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && computer.GetComponent<Puzzle>().canPuzzle)
        {
            comppuzzlepanel.SetActive(true);
            //Time.timeScale = 0;
            //SceneManager.LoadScene("ComputerPuzzle", LoadSceneMode.Additive);
        }
        if (!computer.GetComponent<Puzzle>().canPuzzle)
        {
            comppuzzlepanel.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!computer.GetComponent<Puzzle>().isDone)
        {
            computer.GetComponent<Puzzle>().canPuzzle = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        computer.GetComponent<Puzzle>().canPuzzle = false;
    }

}
