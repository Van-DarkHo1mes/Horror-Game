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

    private CharacterController characterController;
    private Animator animator;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

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
            animator.SetInteger("condition", 3);
            characterController.height = crouchHeight; // ������ ��������� �� ���������

            currentSpeed = Mathf.Lerp(currentSpeed, crouchSpeed, Time.deltaTime * smoothSpeed);
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("condition", 2);

            currentSpeed = Mathf.Lerp(currentSpeed, runSpeed, Time.deltaTime * smoothSpeed);
        }
        else if (horizontalInrut == 0.0f && verticalInput == 0.0f)
        {
            animator.SetInteger("condition", 0);

            currentSpeed = 0.0f; // ���� ����� ������� �������� ������ ��������� ��������, ����� ��������� �����������
        }
        else
        {
            animator.SetInteger("condition", 1);
            characterController.height = standHeight;

            currentSpeed = Mathf.Lerp(currentSpeed, moveSpeed, Time.deltaTime * smoothSpeed);
        }

        // �������� �� ��� �� ���������
        if (isCrouching && Input.GetKey(KeyCode.LeftShift))
        {
            animator.SetInteger("condition", 3);

            currentSpeed = Mathf.Lerp(currentSpeed, crouchSpeed, Time.deltaTime * smoothSpeed);
        }

        // ���������� ������
        characterController.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
