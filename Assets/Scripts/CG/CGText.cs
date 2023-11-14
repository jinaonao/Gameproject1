using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CGText : MonoBehaviour
{
    public GameObject text1;
    public GameObject text2;
    public GameObject text3;
    public GameObject text4;
    public bool is1 = true;
    public bool is2 = false;
    public bool is3 = false;
    public bool is4 = false;

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (is1)
            {
                text1.SetActive(false);
                text2.SetActive(true);
                is1 = false;
                is2 = true;
            }
            else if (is2)
            {
                text2.SetActive(false);
                text3.SetActive(true);
                is2 = false;
                is3 = true;
            }
            else if (is3)
            {
                text3.SetActive(false);
                text4.SetActive(true);
                is3 = false;
                is4 = true;
            }
            else if (is4)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }
}
