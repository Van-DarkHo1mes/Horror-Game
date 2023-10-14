using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float currentSpeed = 0.0f; // ������� �������� ��������
    private float moveSpeed = 5.0f; // �������� ����������� ��������� ��� ������
    private float runSpeed = 10.0f; // �������� ����������� ��������� ��� ����
    private float crouchSpeed = 3.0f; // �������� ����������� ��������� �� ���������

    private bool isCrouching = false; // ��������� �� ���������

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
        // ���������� �������(����) ������
        float horizontalInrut = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // ���������� ����������� ��������
        Vector3 moveDirection = transform.forward * verticalInput + transform.right * horizontalInrut;

        // ������ ���������� �� ������
        moveDirection.y -= 9.81f * Time.deltaTime;

        // �������� �� ��������
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching; // ������������ ��������� ��������
        }

        // ��������� �������� ������
        if (isCrouching)
        {
            currentSpeed = crouchSpeed;
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed; // ���� Shift �����, �������� ���������� ������ runSpeed
        }
        else
        {
            currentSpeed = moveSpeed;
        }

        // �������� �� ��� �� ���������
        if (isCrouching && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = crouchSpeed;
        }

        // ���������� ������
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
