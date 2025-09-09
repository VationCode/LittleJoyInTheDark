using System.Collections;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    [SerializeField] Animator m_animator;

    public void PlayWalkAni(float speed)
    {
        m_animator.SetFloat("Speed", speed);
    }
    public void PlayFlashAni(float time)
    {
        m_animator.SetBool("IsFlash", true);
        StartCoroutine(PlayAnimeTimeCoroutine(time, SkillType.Flash));
    }

    public void PlayMapScanAni(float time)
    {
        m_animator.SetBool("IsMapScan", true);
        StartCoroutine(PlayAnimeTimeCoroutine(time, SkillType.MapScan));
    }

    public void PlayDeadAni()
    {
        m_animator.SetBool("IsDead", true);
    }

    private IEnumerator PlayAnimeTimeCoroutine(float time, SkillType skillType)
    {
        yield return new WaitForSeconds(time);
        switch(skillType)
        {
            case SkillType.Flash:
                m_animator.SetBool("IsFlash", false);
                break;
            case SkillType.MapScan:
                m_animator.SetBool("IsMapScan", false);
                break;
        }
        
    }

    public void PlayReadyPushAni(bool canPush)
    {
        m_animator.SetBool("CanPush", canPush);
    }
    public void PlayPushAni(bool isPush)
    {
        m_animator.SetBool("IsPush", isPush);
    }
}
