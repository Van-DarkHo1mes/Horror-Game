using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeItemInventory : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private float distance = 2.0f;
    [SerializeField] private Camera fpcCamera;
    [SerializeField] private InventoryItem item;
    [SerializeField] private Rigidbody rb;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = fpcCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, distance) && Input.GetKeyDown(KeyCode.E))
            {
                inventory.AddItem(item);

                Destroy(gameObject);
            }
        }
    }
}
