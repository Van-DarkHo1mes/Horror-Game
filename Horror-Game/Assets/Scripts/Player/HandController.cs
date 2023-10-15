using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Transform handTransform; // Ссылка на Transform руки
    private GameObject currentItem; // Текущий предмет в руке

    public void SwitchToItem(GameObject itemPrefab)
    {
        if (currentItem != null)
        {
            Destroy(currentItem);
        }

        currentItem = Instantiate(itemPrefab, handTransform);
    }
}
