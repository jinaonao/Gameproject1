using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupCard : MonoBehaviour
{
    public GameObject objectPrefab; // �������������Ԥ����
    public bool havecard = false;

    public void OnButtonClick()
    {
        if (!havecard)
        {
            GameObject newInstance = Instantiate(objectPrefab, new Vector2(0, 0), Quaternion.identity);

            // Ȼ���ȡʵ���ϵ� Pickup ����������� itemID
            Pickup pickupComponent = newInstance.GetComponent<Pickup>();
            if (pickupComponent != null)
            {
                pickupComponent.itemID = 4;
            }

            havecard = true;
        }
    }
}
