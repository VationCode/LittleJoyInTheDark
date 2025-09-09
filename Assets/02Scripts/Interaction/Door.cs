using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : InteractionComponent
{
    [SerializeField] 
    private Animator m_doorAniamtor;
    [SerializeField]
    private float m_closedAniTime = 1.0f;
    [SerializeField]
    private Collider[] m_doorColliders;
    [SerializeField]
    private AudioClip m_openClip;
    [SerializeField]
    private AudioClip m_closeClip;

    private bool m_isLocked = true;
    private bool m_isOpend = false;
    
    public override bool Interact(PlayerInventory inventory)
    {
        if (m_isLocked && (inventory == null || !inventory.HasKey(InteractionData.ID)))
        {
            LockedDoor();
            return false;
        }
        inventory.RemoveKey(InteractionData.ID);
        if (!m_isOpend)
            Open();
        else
            Close();

        return true;
    }
   
    public void Open()
    {
        m_isOpend = true;
        if(m_doorColliders.Length > 0)
        {
            for (int i = 0; i < m_doorColliders.Length; i++)
            {
                m_doorColliders[i].enabled = false;
            }
        }

        AudioClip _clip = m_openClip;
            AudioManager.Instance.PlayOpenedDoor(m_openClip);

        m_doorAniamtor.SetBool("IsOpen", true);
        m_doorAniamtor.SetBool("IsClose", false);
    }

    public void Close()
    {
        m_isOpend = false;

        StartCoroutine(DelayDoorSound());
        m_doorAniamtor.SetBool("IsOpen", false);
        m_doorAniamtor.SetBool("IsClose", true);
    }
    IEnumerator DelayDoorSound()
    {
        yield return new WaitForSeconds(m_closedAniTime);
        AudioManager.Instance.PlayClosedDoor();
        if (m_doorColliders.Length > 0)
        {
            for (int i = 0; i < m_doorColliders.Length; i++)
            {
                m_doorColliders[i].enabled = true;
            }
        }
    }

    public void LockedDoor()
    {
        AudioManager.Instance.PlayLockedDoorSound();
    }
}
