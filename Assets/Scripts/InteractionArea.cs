using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionArea : MonoBehaviour
{
    public GameObject interactionPrompt;
    private void Start()
    {
        interactionPrompt.SetActive(false); // 默认隐藏提示
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // 确保玩家有一个"Player"的tag
        {
            interactionPrompt.SetActive(true); // 显示提示
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            interactionPrompt.SetActive(false); // 隐藏提示
        }
    }
}
