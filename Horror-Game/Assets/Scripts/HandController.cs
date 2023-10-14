using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform handTransform; // ������ �� Transform ����
    private GameObject currentItem; // ������� ������� � ����

    public void SwitchToItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        currentItem = Instantiate(itemPrefab, handTransform);
    }
}
