using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    // ������ ���� Ŭ������ ������ �ʰ� ItemObject�� ��� �����ۿ� �����ϱ� ���� �ۼ�(�к��ϱ� ���� �ݺ����� �ۼ����� �ʾƵ� �ȴ�)

    public string GetInteractPrompt();
    public void OnInteract();
}

public class ItemObject : MonoBehaviour, IInteractable
{
    public ItemData data;

    private Outline outline;
    public bool isHit = false;

    void Awake()
    {
        outline = GetComponent<Outline>();
    }

    private void OnEnable()
    {
        outline.enabled = isHit;
    }


    public string GetInteractPrompt()
    {
        string str = $"{data.displayName} \n{data.description}";
        return str;
    }

    public void OnInteract()
    {
        CharacterManager.Instance.Player.itemData = data; // CharacterManager�� ���� Player���� ���� �Ѱ���.
        CharacterManager.Instance.Player.addItem?.Invoke(); // addItem�� �ʿ��� ��� ������Ŵ.
        Destroy(gameObject);
    }

}
