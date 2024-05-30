using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Interaction : MonoBehaviour
{
    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    public GameObject curInteractGameObject;
    private IInteractable curInteractable; // GetInteractPrompt() 와 OnInteract() 사용가능 (캐싱)

    public TextMeshProUGUI promptText;
    private Camera camera;

    private PlayerCondition condition;

    public ItemObject item;

    private void Start()
    {
        camera = Camera.main;
        condition = GetComponent<PlayerCondition>();
    }


    void Update()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, (Screen.height / 2) - 2, 6));

            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * maxCheckDistance, Color.red, 1f);

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    if (curInteractGameObject != null)
                    {
                        Outline outline = curInteractGameObject.GetComponent<Outline>();
                        if (outline != null)
                        {
                            outline.enabled = false;
                        }
                    }

                    // Outline 활성화

                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                // Outline 비활성화

                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text = curInteractable.GetInteractPrompt();
    }

    public void OnInteractInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && curInteractable != null)
        {
            curInteractable.OnInteract();

            if (curInteractGameObject.GetComponent<ItemObject>().data.type == ItemType.Consumable)
            {
                ItemDataConsumable[] consumables = curInteractGameObject.GetComponent<ItemObject>().data.consumables;
                foreach (ItemDataConsumable consumable in consumables)
                {
                    switch (consumable.type)
                    {
                        case ConsumableType.Health:
                            condition.Heal(consumable.value);
                            break;
                        case ConsumableType.Stamina:
                            condition.Drink(consumable.value);
                            break;
                    }
                }

                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }
}
