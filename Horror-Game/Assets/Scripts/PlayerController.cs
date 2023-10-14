using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // Скорость перемещения персонажа

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        //Считывание клавишь(ввод) игрока
        float horizontalInrut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //Вычисление направления движения
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInrut;

        //Влияне гравитации на игрока
        moveDirection.y -= 9.81f * Time.deltaTime;

        //Перемещаем игрока
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
