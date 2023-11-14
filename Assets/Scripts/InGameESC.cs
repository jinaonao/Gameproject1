using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameESC : MonoBehaviour
{
    public GameObject ESC;
    private bool ifinESC = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!ifinESC)
            {
                ESC.SetActive(true);
                Time.timeScale = 0;
                ifinESC = true;
            }
            else if (ifinESC)
            {
                ESC.SetActive(false);
                Time.timeScale = 1;
                ifinESC = false;
            }
        }
        /*if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (ifinESC)
            {
                ESC.SetActive(false);
                Time.timeScale = 1;
                ifinESC = false;
            }
        }*/
    }
    public void onYesButton()
    {
        Application.Quit();
    }
    public void onNoButton()
    {
        ESC.SetActive(false);
        ifinESC = false;
        Time.timeScale = 1;
    }

    public void onHomeButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 2);
    }
}
