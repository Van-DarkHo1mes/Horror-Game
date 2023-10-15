using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;

    public HandController handController; // ������ �� ������ HandController


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // ����� �������� 1 (��������, ������)
            SwitchToItem(InventorySlot.Item1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            // ����� �������� 2 (��������, �������)
            SwitchToItem(InventorySlot.Item2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            // ����� �������� 3 (��������, ������)
            SwitchToItem(InventorySlot.Item3);
        }
    }

    public enum InventorySlot
    {
        Item1,
        Item2,
        Item3
    }

    public InventorySlot currentInventorySlot = InventorySlot.Item1;

    void SwitchToItem(InventorySlot item)
    {
        switch (item)
        {
            case InventorySlot.Item1:
                handController.SwitchToItem(null);
                break;
            case InventorySlot.Item2:
                handController.SwitchToItem(inventory.useItem[0].itemPrefab);
                break;
            case InventorySlot.Item3:
                handController.SwitchToItem(inventory.useItem[1].itemPrefab);
                break;
        }
    }
}
