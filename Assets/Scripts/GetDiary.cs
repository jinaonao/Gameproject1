using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetDiary : MonoBehaviour
{
    public Button[] clickableAreas; // ����ĸ�͸����ť
    public TextMeshProUGUI[] explanations;     // ��Ӧ���ĸ������ı���
    private int clickedCount = 0;   // ������Ĳ��ֵļ�����
    public GameObject diary;

    private void Start()
    {
        // ��ʼ��
        for (int i = 0; i < clickableAreas.Length; i++)
        {
            int index = i; // Ϊ�˱���հ�����
            clickableAreas[i].onClick.AddListener(() => ShowExplanation(index));
            explanations[i].gameObject.SetActive(false); // ��ʼʱ�������н���
        }
    }

    public void ShowExplanation(int index)
    {
        explanations[index].gameObject.SetActive(true); // ��ʾ��Ӧ�Ľ���
        clickableAreas[index].interactable = false;     // �����ѵ���İ�ť
        clickedCount++;                                // ���¼�����

        // ������в��ֶ�������ˣ����������������������߼���������ʾUI�ռǱ�
        if (clickedCount == 4)
        {
            diary.SetActive(true);
        }
    }
}
