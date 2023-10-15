using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] public List<InventoryItem> useItem = new List<InventoryItem>();
    public List<InventoryItem> InventoryItems = new List<InventoryItem>();

    void Start()
    {
        for (int i = 0; i < useItem.Count; i++)
        {
            AddItem(useItem[i]);
        }
    }

    private void AddItem(InventoryItem item)
    {
        InventoryItems.Add(item);
    }
}
