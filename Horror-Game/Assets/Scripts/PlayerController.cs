using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Скорость и Перемещение игрока
    private float currentSpeed = 0.0f; // Текущая скорость персоажа

    [SerializeField] private float moveSpeed; // Скорость перемещения персонажа при ходьбе
    [SerializeField] private float runSpeed; // Скорость перемещения персонажа при беге
    [SerializeField] private float crouchSpeed; // Скорость перемещения персонажа на корточках
    [SerializeField][Range(1, 10)] private float smoothSpeed; // Плавное изменение скорости

    // Ссостояние игрока 
    private bool isCrouching = false; // Состояния на корточках

    [SerializeField] private float standHeight; // Высота игрока при бездействии
    [SerializeField] private float crouchHeight; // Высота игрока на корточках

    // Компоненты принадлежащие Player
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
        moveDirection.y -= 100.0f * Time.deltaTime;

        // Проверка на корточки
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching; // Переключение состояния на корточки
        }

        // Изменение скорости игрока
        if (isCrouching)
        {
            characterController.height = crouchHeight; // Высота персонажа на корточках

            currentSpeed = Mathf.Lerp(currentSpeed, crouchSpeed, Time.deltaTime * smoothSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, Time.deltaTime * smoothSpeed);
        }
        else
        {
            characterController.height = standHeight;

            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * smoothSpeed);
        }

        // Проверка на бег на корточках
        if (isCrouching && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, crouchSpeed, Time.deltaTime * smoothSpeed);
        }

        // Перемещаем игрока
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
