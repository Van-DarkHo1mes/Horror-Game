using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private Inventory inventory;
    [SerializeField] private RectTransform itemsPanel;

    readonly List<GameObject> drawIcons = new List<GameObject>();

    void Start()
    {
        inventory.onItemAdded += OnItemAdded;

        Redraw();
    }

    void OnItemAdded(InventoryItem obj)
    {
        Redraw();
    }

    private void Redraw()
    {
        ClearDrawn();

        for (var i = 0; i < inventory.InventoryItems.Count; i++)
        {
            InventoryItem item = inventory.InventoryItems[i];

            GameObject icon = new GameObject("Icon");

            Image image = icon.AddComponent<Image>();

            image.sprite = item.itemIcon;

            icon.transform.SetParent(itemsPanel);

            drawIcons.Add(icon);
        }
    }

    void ClearDrawn()
    {
        for (int i = 0; i < drawIcons.Count; i++)
        {
            Destroy(drawIcons[i]);
        }
    }
}
