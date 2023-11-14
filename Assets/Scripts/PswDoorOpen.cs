using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PswDoorOpen : MonoBehaviour
{
    private Animator animator;
    public GameObject sign;
    public GameObject wrong;
    public GameObject findans;
    public GameObject interactionPrompt;

    private bool IsAtTrigger = false;
    private bool IsDoorOpen = false;
    private bool Isfirsttime = true;
    private bool IsFinding = false;
    private bool Iswrong = false;

    [SerializeField]private TextMeshProUGUI CodeText;
    string codeTextValue = "";
    public string Password;
    public GameObject CodePanel;
    void Start()
    {
        animator = GetComponent<Animator>();
        interactionPrompt.SetActive(false);
    }

    void Update()
    {
        CodeText.text = codeTextValue;

        if(codeTextValue == Password)
        {
            animator.SetTrigger("PswTrue");
            CodePanel.SetActive(false);
            IsDoorOpen = true;
            Iswrong = false;
        }
        if(codeTextValue.Length >= 4)
        {
            codeTextValue = "";
            wrong.SetActive(true);
            Iswrong = true;
        }
        if(Input.GetKeyDown(KeyCode.E) && IsAtTrigger == true && IsDoorOpen == false) 
        {
            CodePanel.SetActive(true);
        }
        Highlight();
        if(IsFinding && Input.GetKeyDown(KeyCode.E))
        {
            findans.SetActive(false);
            IsFinding = false;
            Isfirsttime = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && !IsDoorOpen)
        {
            IsAtTrigger = true;
            interactionPrompt.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        IsAtTrigger = false;
        CodePanel.SetActive(false);
        codeTextValue = "";
        wrong.SetActive(false);
        interactionPrompt.SetActive(false);
        if (!IsDoorOpen && Isfirsttime && Iswrong)
        {
            findans.SetActive(true);
            IsFinding = true;
        }
    }
    public void addDigit(string digit)//输入数字
    {
        codeTextValue += digit;
    }
    private void Highlight()//标记
    {
        if (IsAtTrigger == true && IsDoorOpen == false)
        {
            sign.SetActive(true);
        }
        else { sign.SetActive(false); }
    }
}
