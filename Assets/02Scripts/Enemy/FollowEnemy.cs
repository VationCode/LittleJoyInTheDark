using UnityEngine;

public class FollowEnemy : Enemy
{
    private bool isFollow = false;
    [Range(0.1f, 2f),SerializeField]
    private float m_followSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        m_CurrentState = EnemyState.Chase;
    }

    public void StartFollow()
    {
        isFollow = true;
    }
    protected override void BaseState()
    {
        m_CurrentState = EnemyState.Chase;
    }

    protected override void ChaseTarget()
    {
        if (!isFollow) return;

        if(m_EnemyType == EnemyType.Skeleton)
        {
            base.ChaseTarget();
            m_Animator.SetBool("IsChase", true);
            return;
        }
        Vector3 _dir = (m_Target.transform.position - this.transform.position).normalized;
        float _dis = Vector3.Distance(m_Target.transform.position, this.transform.position);

        //if (_dis > m_ChaseDistance) return;

        transform.Translate(_dir * Time.deltaTime * m_followSpeed, Space.World);
        transform.LookAt(m_Target.transform.position);
    }
}
