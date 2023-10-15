using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Action<InventoryItem> onItemAdded;

    [SerializeField] public List<InventoryItem> useItem = new List<InventoryItem>();
    public List<InventoryItem> InventoryItems { get; private set; }

    void Awake()
    {
        InventoryItems = new List<InventoryItem>();

        for (int i = 0; i < useItem.Count; i++)
        {
            AddItem(useItem[i]);
        }
    }

    public void AddItem(InventoryItem item)
    {
        InventoryItems.Add(item);

        onItemAdded?.Invoke(item);
    }
}
