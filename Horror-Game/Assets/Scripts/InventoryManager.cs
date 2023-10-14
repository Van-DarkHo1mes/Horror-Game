using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<InventoryItem> items = new List<InventoryItem>();

    public void AddItem(InventoryItem item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItem item)
    {
        items.Remove(item);
    }

    public void UseItem(InventoryItem item)
    {
        // В зависимости от типа предмета, выполните соответствующие действия
        if (item.isUsable)
        {
            // Добавьте здесь код для использования предмета
        }
    }
}
