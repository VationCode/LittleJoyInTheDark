using Unity.VisualScripting;
using UnityEngine;

public class PushBox : MonoBehaviour, IApplyPush
{
    [SerializeField]
    private LayerMask m_layerMask;
    float castOffset = 0.1f; // 여유 거리
    public void Push(GameObject player, Vector3 dir, float speed)
    {
        // 박스방향으로 밀때만 밀어지도록 계산
        Vector3 _pushDir = (transform.position - player.transform.position).normalized;
        _pushDir.y = 0; // 수평 방향만 밀기
        float _dot = Vector3.Dot(dir.normalized, _pushDir);

        // 박스와 다른 사물이 충돌되었을 때 Translate(뚫고지나감) 멈추기 위한 체크
        dir.Normalize();
        float moveDistance = speed * Time.deltaTime;
        Vector3 _start = transform.position + Vector3.up * 0.5f;

        if (_dot > 0.5f)
        {
            if (!Physics.Raycast(_start, dir, moveDistance + castOffset, m_layerMask))
            {
                transform.Translate(dir * speed * Time.deltaTime * 0.5f);
                AudioManager.Instance.PlayPushBox();
            }
        }
    }
}
