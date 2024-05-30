using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    private PlayerController controller;
    public Vector3 offset = new Vector3(0f, 2f, -6f);

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    void Start()
    {
        transform.position = CharacterManager.Instance.Player.transform.position + offset;
    }
   
}
