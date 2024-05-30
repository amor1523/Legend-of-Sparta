using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 300f; // �����밡 ���� ���� ũ��

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // ĳ���Ϳ� �浹�ߴ��� Ȯ��
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); // �浹�� ��ü�� Rigidbody ��������
            if (rb != null)
            {
                // �����뿡 �������� �� �������� ���� ���� ĳ���͸� ���� �پ� ������ ��
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
