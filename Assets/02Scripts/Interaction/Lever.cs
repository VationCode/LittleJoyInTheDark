using UnityEngine;

public class Lever : InteractionComponent
{
    [SerializeField] 
    private Animator m_animator;
    [SerializeField]
    private Animator m_trapDoorAnimator;
    [SerializeField]
    private Collider m_trapGroundcollider;
    [SerializeField] 
    private Collider m_collider;

    private bool m_isOpened = false;
    public override bool Interact(PlayerInventory inventory)
    {
        m_isOpened = !m_isOpened;
        m_animator.SetBool("Switched", m_isOpened);
        m_collider.enabled = false;
        AudioManager.Instance.PlayLever();
        m_trapDoorAnimator.SetBool("Switched", false);
        m_trapGroundcollider.enabled = true;
        return m_isOpened;
    }
}
