using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public GameObject popupUI;

    public void OnItemClicked()
    {
        popupUI.SetActive(true);
    }
}
