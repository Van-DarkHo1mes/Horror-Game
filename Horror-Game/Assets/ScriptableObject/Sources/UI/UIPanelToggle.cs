using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelToggle : MonoBehaviour
{
    public GameObject panel; // ������ �� ���� UI ������

    void Start()
    {
        // �������� ������ ��� ������� ����
        panel.SetActive(false);
    }

    void Update()
    {
        // ���������, ���� �� ������ ������� TAB
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // ����������� ��������� ������
            panel.SetActive(!panel.activeSelf);
        }
    }
}
