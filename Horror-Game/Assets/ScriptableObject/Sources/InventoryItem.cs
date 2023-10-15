using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData",menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription; // Описание предмета
    public Sprite itemIcon; // Иконка предмета для отображения в интерфейсе
    public GameObject itemPrefab; // Ссылка на префаб объекта в 3D-мире (например, модель фонарика или камеры)
    public bool isUsable; // Может ли предмет быть использован
    public int itemValue; // Значение предмета, если применимо (например, ключи или ценные предметы)

}
