using HutongGames.PlayMaker.Actions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCDialog : MonoBehaviour
{
    public GameObject talk;
    public GameObject image;
    public GameObject[] dialogText;
    public bool canTalk;
    public bool isTalking;
    private int currentTextIndex = 0; // ��ǰ��ʾ���ı�����

    void Start()
    {
        canTalk = false;
        isTalking = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (canTalk && !isTalking)
            {
                talk.SetActive(true);
                image.SetActive(true);
                dialogText[currentTextIndex].SetActive(true);
                isTalking = true;
            }
            else if (isTalking)
            {
                // ������ڽ��жԻ����رյ�ǰҳ��
                dialogText[currentTextIndex].SetActive(false);

                // �ƶ�����һҳ������Ի�
                currentTextIndex++;
                if (currentTextIndex < dialogText.Length)
                {
                    dialogText[currentTextIndex].SetActive(true);
                }
                else
                {
                    // ����Ի��������ر����д��ڲ�����
                    talk.SetActive(false);
                    image.SetActive(false);
                    //dialogText[currentTextIndex].SetActive(false);
                    isTalking = false;
                    currentTextIndex = 0; // �����ı�����
                }
            }
        }
        if (!canTalk)
        {
            talk.SetActive(false);
            image.SetActive(false);
            dialogText[currentTextIndex].SetActive(false);
            currentTextIndex = 0; // �����ı�����
            isTalking = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        canTalk = true;
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        canTalk = false;
    }
}
