using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum EnemyType
{
    PatrolGhost,
    FollowGhost,
    RabbitGhost,
    Skeleton
}

public enum EnemyState
{
    FlashStop,
    Patrol,
    Chase,
}

public class Enemy : MonoBehaviour, IApplyFlash
{
    [SerializeField]
    protected Animator m_Animator;
    [SerializeField] 
    protected EnemyType m_EnemyType;
    [SerializeField] 
    protected NavMeshAgent m_NavAgent;
    [SerializeField] 
    protected EnemyState m_CurrentState;
    protected GameObject m_Target;
    [Space(10)]

    [Header("[ AI ]")]
    [SerializeField] 
    protected float m_ChaseDistance;
    [Space(10)]

    [Header("[ FlashLight Hit ]")]
    [SerializeField] 
    private ParticleSystem m_stopParticle;
    [SerializeField] 
    private GameObject m_deadZone;
    [SerializeField] 
    private float m_flashStopTime; 
    

    private bool m_isHitFlash;
    private void Awake()
    {
        if (GetComponent<NavMeshAgent>() != null)
            m_NavAgent = GetComponent<NavMeshAgent>();

        m_Target = GameObject.FindGameObjectWithTag("Player");
    }
    public void init()
    {
        
    }

    protected virtual void Start()
    {
        if(m_stopParticle != null) m_stopParticle.Stop();

    }


   private void Update()
    {
        float _distance = Vector3.Distance(m_Target.transform.position, this.transform.position);

        if (m_NavAgent == null) return;

        // 추적 거리에 들어왔을 시
        switch (m_CurrentState)
        {
            case EnemyState.FlashStop:
                if (m_EnemyType == EnemyType.PatrolGhost)
                    m_NavAgent.SetDestination(transform.position);
                break;
            case EnemyState.Patrol:
                // pathPending :NavMeshAgent가 새 경로 계산 중인지 확인
                // m_IsMoving : 중복방지
                if (!m_NavAgent.pathPending && m_NavAgent.remainingDistance < 0.1f)
                {
                    Patrol();
                }
                else if (_distance < m_ChaseDistance)
                {
                    m_CurrentState = EnemyState.Chase;
                }
                break;
            case EnemyState.Chase:
                {
                    ChaseTarget();
                    
                    if (_distance > m_ChaseDistance)
                    {
                        BaseState();
                    }
                }
                break;
        }
    }


    #region ================================================================================ State
    protected virtual void ChaseTarget()
    {
        m_NavAgent.SetDestination(m_Target.transform.position);
    }
    protected virtual void Patrol(){}
    protected virtual void BaseState(){}
    #endregion ================================================================================ /State

    #region ================================================================================ HitFlash
    public void ApplyFlash(float flashDuration)
    {
        if (m_isHitFlash) return;
        if (m_EnemyType == EnemyType.RabbitGhost) return;

        m_CurrentState = EnemyState.FlashStop;
        m_isHitFlash = true;
        HitFlash(flashDuration);
        m_deadZone.SetActive(false);
    }
    private void HitFlash(float flashDuration)
    {
        if (m_stopParticle != null) m_stopParticle.Play();
        StartCoroutine(StopEnemyCoroutine(flashDuration));
    }

    private IEnumerator StopEnemyCoroutine(float flashDuration)
    {
        yield return new WaitForSeconds(flashDuration + m_flashStopTime);
        if (m_stopParticle != null) m_stopParticle.Stop();

        yield return new WaitForSeconds(m_flashStopTime);
        m_deadZone.SetActive(true);
        m_isHitFlash = false;
        BaseState();
    }
    #endregion ================================================================================ /HitFlash

}
