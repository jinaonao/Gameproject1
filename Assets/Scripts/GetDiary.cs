using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetDiary : MonoBehaviour
{
    public Button[] clickableAreas; // 你的四个透明按钮
    public TextMeshProUGUI[] explanations;     // 对应的四个解释文本框
    private int clickedCount = 0;   // 被点击的部分的计数器
    public GameObject diary;

    private void Start()
    {
        // 初始化
        for (int i = 0; i < clickableAreas.Length; i++)
        {
            int index = i; // 为了避免闭包问题
            clickableAreas[i].onClick.AddListener(() => ShowExplanation(index));
            explanations[i].gameObject.SetActive(false); // 初始时隐藏所有解释
        }
    }

    public void ShowExplanation(int index)
    {
        explanations[index].gameObject.SetActive(true); // 显示对应的解释
        clickableAreas[index].interactable = false;     // 禁用已点击的按钮
        clickedCount++;                                // 更新计数器

        // 如果所有部分都被点击了，你可以在这里添加其他的逻辑，例如显示UI日记本
        if (clickedCount == 4)
        {
            diary.SetActive(true);
        }
    }
}
