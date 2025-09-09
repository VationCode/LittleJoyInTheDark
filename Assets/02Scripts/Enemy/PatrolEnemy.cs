using UnityEngine;

public class PatrolEnemy : Enemy
{
    public Transform[] waypoints;
    private int m_currentWaypoint;
    private bool m_isBackLoad = false;
    private bool m_isPatrolMoving = false;
    protected override void Start()
    {
        base.Start();
        m_CurrentState = EnemyState.Patrol;
    }


    protected override void Patrol()
    {
        if (waypoints.Length == 0)
        {
            m_NavAgent.SetDestination(transform.position);
            return;
        }
        //Debug.Log(this.gameObject.name + " Patrol ");
        if (!m_isBackLoad)
        {
            m_currentWaypoint++;
            if (m_currentWaypoint == waypoints.Length - 1) m_isBackLoad = true;
        }
        else
        {
            --m_currentWaypoint;
            if (m_currentWaypoint == 0) m_isBackLoad = false;
        }

        m_NavAgent.SetDestination(waypoints[m_currentWaypoint].position);
    }
    protected override void BaseState()
    {
        m_CurrentState = EnemyState.Patrol;
    }
    protected override void ChaseTarget()
    {
        base.ChaseTarget();
    }
}
