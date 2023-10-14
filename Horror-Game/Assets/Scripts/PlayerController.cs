using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // �������� � ����������� ������
    private float currentSpeed = 0.0f; // ������� �������� ��������

    [SerializeField] private float moveSpeed; // �������� ����������� ��������� ��� ������
    [SerializeField] private float runSpeed; // �������� ����������� ��������� ��� ����
    [SerializeField] private float crouchSpeed; // �������� ����������� ��������� �� ���������
    [SerializeField][Range(1, 10)] private float smoothSpeed; // ������� ��������� ��������

    // ���������� ������ 
    private bool isCrouching = false; // ��������� �� ���������

    [SerializeField] private float standHeight; // ������ ������ ��� �����������
    [SerializeField] private float crouchHeight; // ������ ������ �� ���������

    // ���������� ������������� Player
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
        moveDirection.y -= 100.0f * Time.deltaTime;

        // �������� �� ��������
        if (Input.GetKeyDown(KeyCode.C))
        {
            isCrouching = !isCrouching; // ������������ ��������� �� ��������
        }

        // ��������� �������� ������
        if (isCrouching)
        {
            characterController.height = crouchHeight; // ������ ��������� �� ���������

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

        // �������� �� ��� �� ���������
        if (isCrouching && Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = Mathf.Lerp(currentSpeed, crouchSpeed, Time.deltaTime * smoothSpeed);
        }

        // ���������� ������
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
