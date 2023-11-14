using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public GameObject interactionPrompt;
    private void Start()
    {
        interactionPrompt.SetActive(false); // Ĭ��������ʾ
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ȷ�������һ��"Player"��tag
        {
            interactionPrompt.SetActive(true); // ��ʾ��ʾ
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(false); // ������ʾ
        }
    }
}
