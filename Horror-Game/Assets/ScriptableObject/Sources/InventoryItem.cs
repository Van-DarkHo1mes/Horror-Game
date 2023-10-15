using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemData",menuName = "Inventory/Item")]
public class InventoryItem : ScriptableObject
{
    public string itemName;
    public string itemDescription; // �������� ��������
    public Sprite itemIcon; // ������ �������� ��� ����������� � ����������
    public GameObject itemPrefab; // ������ �� ������ ������� � 3D-���� (��������, ������ �������� ��� ������)
    public bool isUsable; // ����� �� ������� ���� �����������
    public int itemValue; // �������� ��������, ���� ��������� (��������, ����� ��� ������ ��������)

}
