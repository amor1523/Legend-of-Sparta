using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    public float jumpForce = 300f; // 점프대가 가할 힘의 크기

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player")) // 캐릭터와 충돌했는지 확인
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>(); // 충돌한 객체의 Rigidbody 가져오기
            if (rb != null)
            {
                // 점프대에 접촉했을 때 순간적인 힘을 가해 캐릭터를 위로 뛰어 오르게 함
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }
}
