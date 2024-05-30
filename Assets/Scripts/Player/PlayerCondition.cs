using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerCondition : MonoBehaviour
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }
    Condition stamina {  get { return uiCondition.stamina; } }

    void Update()
    {
        health.Subtract(health.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if (health.curValue < 0f)
        {
            Die();
        }

    }

    public void Heal(float amount)
    {
        health.Add(amount);
    }

    public void Drink(float amount)
    {
        stamina.Add(amount);
    }

    private void Die()
    {
        Debug.Log("죽었다.");
        // TODO :: GameOver UI 띄우고 버튼으로 재시작 버튼
    }
}
