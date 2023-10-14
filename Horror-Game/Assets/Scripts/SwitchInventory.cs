using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchInventory : MonoBehaviour
{
    public GameObject item2Prefab; // ������ �� ������ �������� 2 (��������, �������)
    public GameObject item3Prefab; // ������ �� ������ �������� 3 (��������, ������)
    public HandController handController; // ������ �� ������ HandController
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
                handController.SwitchToItem(item2Prefab);
                break;
            case InventorySlot.Item3:
                handController.SwitchToItem(item3Prefab);
                break;
        }
    }
}
