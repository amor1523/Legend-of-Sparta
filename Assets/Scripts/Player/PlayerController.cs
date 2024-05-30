using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumpForce;
    public LayerMask groundLayerMask; // 자기 자신이 Layer에 감지되는 경우 방지하기위해 선언한 변수

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    public Vector2 mouseDelta;
    
    [HideInInspector]
    public bool canLook = true;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        cameraContainer = Camera.main.transform.parent;
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    private void CameraLook()
    {
        // camCurXRot 으로 mouseDelta의 y값을 받아온다.
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);

        // 위아래 회전
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        // 좌우 회전
        transform.eulerAngles += new Vector3(0, mouseDelta.x * lookSensitivity, 0);
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }
    
    public void OnLook(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x; // 수평이동 계산
        dir *= moveSpeed;
        dir.y = _rigidbody.velocity.y; // 수직 속도 유지 ( 생략 시 이동할 때마다 수직 속도가 0으로 초기화되어 자연스러운 점프나 낙하 동작이 방해된다)

        _rigidbody.velocity = dir;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        float rayLength = 1.3f; // rayLength조절로 점프 조작감 및 판정을 조절할 수 있다.
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.5f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.5f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.5f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.5f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            //Debug.DrawRay(rays[i].origin, rays[i].direction * rayLength, Color.red, 1f); // Ray시각화
            if (Physics.Raycast(rays[i], rayLength, groundLayerMask))
            {
                return true;
            }
        }
        return false;
    }
}
