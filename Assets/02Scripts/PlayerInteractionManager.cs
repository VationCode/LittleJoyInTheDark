using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(PlayerInventory))]
public class PlayerInteractionManager : MonoBehaviour
{
    [SerializeField]
    private PlayerInput m_input;
    private PlayerInventory m_inventory;
    private List<InteractionComponent> m_nearInteractionList = new();

    private void Awake()
    {
        m_input = GetComponent<PlayerInput>();
        m_inventory = GetComponent<PlayerInventory>();
    }

    private void Update()
    {
        if (m_input.IsInteraction) // F키
        {
            foreach (var interaction in m_nearInteractionList)
            {
                if (interaction.Interact(m_inventory))
                {
                    UIManager.Instance.SetInteractionUI(false);
                    m_nearInteractionList.Remove(interaction);
                    break;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detected InteractionUI
        if (other.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            GameObject partent = other.transform.parent.gameObject;
            if (!partent.TryGetComponent(out InteractionComponent interaction)) return;

            m_nearInteractionList.Add(interaction);
            // Escape클래스를 가진 오브젝트중 F키 안누르고 진행되는 방식도 있어서 그냥 3중으로 일단 만들어 사용....
            if (m_nearInteractionList[m_nearInteractionList.Count - 1].InteractionData.InteractionType == InteractionType.Ending)
            {
                interaction.Interact(m_inventory); ;
                return;
            }

            UIManager.Instance.SetInteractionUI(true);
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Interaction"))
        {
            GameObject partent = other.transform.parent.gameObject;
            if (partent.TryGetComponent(out InteractionComponent interaction))
            {
                UIManager.Instance.SetInteractionUI(false);
                m_nearInteractionList.Remove(interaction);
            }
        }
    }
}
