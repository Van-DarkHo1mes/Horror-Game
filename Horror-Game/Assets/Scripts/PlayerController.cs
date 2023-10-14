using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float currentSpeed = 0.0f; // Текущая скорость персоажа
    private float moveSpeed = 5.0f; // Скорость перемещения персонажа при ходьбе
    private float runSpeed = 10.0f; // Скорость перемещения персонажа при беге
    private float crouchSpeed = 3.0f; // Скорость перемещения персонажа на корточках

    private bool isCrouching = false; // Состояния на корточках

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        // Считывание клавишь(ввод) игрока
        float horizontalInrut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисление направления движения
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInrut;

        // Влияне гравитации на игрока
        moveDirection.y -= 9.81f * Time.deltaTime;

        // Проверка на корточки
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching; // Переключение состояния корточек
        }

        // Изменение скорости игрока
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed; // Если Shift нажат, скорость становится равной runSpeed
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        // Проверка на бег на корточках
        if (isCrouching && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = crouchSpeed;
        }

        // Перемещаем игрока
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
