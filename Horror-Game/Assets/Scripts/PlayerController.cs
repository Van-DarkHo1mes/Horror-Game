using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f; // �������� ����������� ���������

    private CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;
    }

    void Update()
    {
        //���������� �������(����) ������
        float horizontalInrut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //���������� ����������� ��������
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInrut;

        //������ ���������� �� ������
        moveDirection.y -= 9.81f * Time.deltaTime;

        //���������� ������
        characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
