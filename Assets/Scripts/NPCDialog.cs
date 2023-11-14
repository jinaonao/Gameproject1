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
    private int currentTextIndex = 0; // 当前显示的文本索引

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
                // 如果正在进行对话，关闭当前页面
                dialogText[currentTextIndex].SetActive(false);

                // 移动到下一页或结束对话
                currentTextIndex++;
                if (currentTextIndex < dialogText.Length)
                {
                    dialogText[currentTextIndex].SetActive(true);
                }
                else
                {
                    // 如果对话结束，关闭所有窗口并重置
                    talk.SetActive(false);
                    image.SetActive(false);
                    //dialogText[currentTextIndex].SetActive(false);
                    isTalking = false;
                    currentTextIndex = 0; // 重置文本索引
                }
            }
        }
        if (!canTalk)
        {
            talk.SetActive(false);
            image.SetActive(false);
            dialogText[currentTextIndex].SetActive(false);
            currentTextIndex = 0; // 重置文本索引
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
