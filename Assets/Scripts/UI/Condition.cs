using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Condition : MonoBehaviour
{
    public float curValue;
    public float startValue;
    public float maxValue;
    public float passiveValue;
    public Image uiBar;

    void Start()
    {
        curValue = startValue;
    }

    void Update()
    {
        uiBar.fillAmount = GetPercentage();
    }

    float GetPercentage()
    {
        return curValue / maxValue;
    }

    public void Add(float value)
    {
        //curValue += value; 더해주기만 하면 maxValue를 넘는다
        curValue = Mathf.Min(curValue + value, maxValue);
    }

    public void Subtract(float value) // 0보다 작아지지 않도록, -로 갈때는 0이 되도록
    {
        curValue = Mathf.Max(curValue - value, 0);
    }

}
