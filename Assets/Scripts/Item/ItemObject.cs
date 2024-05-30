using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IInteractable
{
    // 아이템 별로 클래스를 만들지 않고 ItemObject로 모든 아이템에 대응하기 위해 작성(분별하기 위한 반복문을 작성하지 않아도 된다)

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
        CharacterManager.Instance.Player.itemData = data; // CharacterManager를 통해 Player에게 정보 넘겨줌.
        CharacterManager.Instance.Player.addItem?.Invoke(); // addItem에 필요한 기능 구독시킴.
        Destroy(gameObject);
    }

}
