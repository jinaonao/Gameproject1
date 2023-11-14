using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCard : MonoBehaviour
{
    public GameObject objectPrefab; // 在这里引用你的预制体
    public bool havecard = false;

    public void OnButtonClick()
    {
        if (!havecard)
        {
            GameObject newInstance = Instantiate(objectPrefab, new Vector2(0, 0), Quaternion.identity);

            // 然后获取实例上的 Pickup 组件，并设置 itemID
            Pickup pickupComponent = newInstance.GetComponent<Pickup>();
            if (pickupComponent != null)
            {
                pickupComponent.itemID = 4;
            }

            havecard = true;
        }
    }
}
