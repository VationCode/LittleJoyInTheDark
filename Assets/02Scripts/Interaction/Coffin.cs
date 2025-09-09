using UnityEngine;

public class Coffin : InteractionComponent
{
    [SerializeField]
    private Animator m_animator;
    [SerializeField]
    private Collider m_collider;
    private bool m_isOpened = false;
    [SerializeField]
    private GameObject m_key;
    public override bool Interact(PlayerInventory inventory)
    {
        if (m_isOpened) return false;
        m_isOpened = !m_isOpened;
        m_animator.SetBool("IsOpen", m_isOpened);
        m_collider.enabled = false;
        m_key.SetActive(true);
        AudioManager.Instance.PlayPushBox();
        return m_isOpened;
    }
}
