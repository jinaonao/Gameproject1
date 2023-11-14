using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DiaryOpen : MonoBehaviour
{
    public bool IsDiaryOpen = false;
    string codeTextValue = "";
    public string Password;
    public GameObject light1;
    public GameObject light2;
    public GameObject light3;
    public GameObject light4;
    public GameObject light5;
    public GameObject light6;
    public GameObject light7;
    public GameObject light8;
    public GameObject light9;

    public GameObject page1;
    public GameObject page2;
    void Start()
    {

    }

    void Update()
    {
        if (codeTextValue == Password)
        {
            IsDiaryOpen = true;
            page1.SetActive(false);
            page2.SetActive(true);
        }
        if (codeTextValue.Length >= 4 && codeTextValue != Password)
        {
            codeTextValue = "";
            light1.SetActive(false);
            light2.SetActive(false);
            light3.SetActive(false);
            light4.SetActive(false);
            light5.SetActive(false);
            light6.SetActive(false);
            light7.SetActive(false);
            light8.SetActive(false);
            light9.SetActive(false);
        }
    }
    public void addDigit(string digit)// ‰»Î ˝◊÷
    {
        codeTextValue += digit;
    }
    public void highlight1()
    {
        light1.SetActive(true);
    }
    public void highlight2()
    {
        light2.SetActive(true);
    }
    public void highlight3()
    {
        light3.SetActive(true);
    }
    public void highlight4()
    {
        light4.SetActive(true);
    }
    public void highlight5()
    {
        light5.SetActive(true);
    }
    public void highlight6()
    {
        light6.SetActive(true);
    }
    public void highlight7()
    {
        light7.SetActive(true);
    }
    public void highlight8()
    {
        light8.SetActive(true);
    }
    public void highlight9()
    {
        light9.SetActive(true);
    }
}
