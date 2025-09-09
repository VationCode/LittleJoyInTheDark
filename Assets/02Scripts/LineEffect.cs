using System.Collections;
using TMPro;
using UnityEngine;

public class LineEffect : MonoBehaviour
{
    [SerializeField]
    private LineRenderer m_lineRenderer;
    [SerializeField]
    private Transform[] linePoses;
    [SerializeField]
    private float m_speed = 2f; // 화살표 이동 속도
    [SerializeField]
    private float m_stopEffectTime;

    private float m_offset = 0f;
    private float m_totalLength;
    private void Awake()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        StartCoroutine(StopLineCoroutine());
    }
    void Start()
    {
        m_lineRenderer.textureMode = LineTextureMode.Tile;
        m_lineRenderer.positionCount = linePoses.Length;

        for (int i = 0; i < linePoses.Length; i++)
        {
            m_lineRenderer.SetPosition(i, linePoses[i].transform.localPosition);
        }
        
        for (int i = 0; i < m_lineRenderer.positionCount - 1; i++)
        {
            m_totalLength += Vector3.Distance(m_lineRenderer.GetPosition(i), m_lineRenderer.GetPosition(i + 1));
        }

    }

    // Update is called once per frame
    void Update()
    {
        m_offset -= Time.deltaTime * m_speed;

        if (m_offset <= -m_totalLength) m_offset = 0f;
        m_lineRenderer.material.SetTextureOffset("_MainTex", new Vector2(m_offset, 0));
    }

    IEnumerator StopLineCoroutine()
    {
        yield return new WaitForSeconds(m_stopEffectTime);
        Destroy(this.gameObject);
    }

}
