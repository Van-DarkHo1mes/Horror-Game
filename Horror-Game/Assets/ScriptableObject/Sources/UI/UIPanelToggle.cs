using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelToggle : MonoBehaviour
{
    public GameObject panel; // Ссылка на вашу UI панель

    void Start()
    {
        // Скрываем панель при запуске игры
        panel.SetActive(false);
    }

    void Update()
    {
        // Проверяем, была ли нажата клавиша TAB
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Инвертируем видимость панели
            panel.SetActive(!panel.activeSelf);
        }
    }
}
