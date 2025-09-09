using UnityEngine;

// 해당 오브젝트에 Trigger시 등록된 유령 Follow시작 그전까진 멈춰있는 상탱
public class FollowStart : MonoBehaviour
{
    [SerializeField] FollowEnemy[] followEnemys;

    private void OnTriggerEnter(Collider other)
    {
     if(other.CompareTag("Player"))
        {
            for (int i = 0; i < followEnemys.Length; i++)
            {
                followEnemys[i].StartFollow();
            }

            Destroy(this);
        }
    }
}
