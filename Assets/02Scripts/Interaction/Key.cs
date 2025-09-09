using System.Collections.Generic;
using UnityEngine;

public class Key : InteractionComponent
{
    [SerializeField] 
    private GameObject m_doorLine;
    
    private void Start()
    {
        if(this.m_doorLine != null)
            m_doorLine.SetActive(false);
    }
    public override bool Interact(PlayerInventory inventory)
    {
        if (inventory == null || inventory.HasKey(InteractionData.ID))
        {
            Debug.Log("aaaa");
            return false;
        }

        PickUpKey();
        inventory.AddKey(InteractionData.ID);
        return true;
    }
    private void PickUpKey()
    {
        if (this.m_doorLine != null)
        {
            m_doorLine.SetActive(true);
        }
        AudioManager.Instance.PlayPickUpSound();
        Destroy(this.gameObject);
    }
}
