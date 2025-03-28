using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum ENEMYTYPE
{
    Gost,
    Gost2,
    Gost3
}

public class Enemy : MonoBehaviour, IFlash
{
    public ENEMYTYPE enemyType;
    float stopT;
    bool isLight;
    NavMeshAgent nav;
    SkinnedMeshRenderer skinnedMeshRenderer;
    Color originColor;
    private GameObject target;
    private bool isFollow;
    private void Awake()
    {
        if (GetComponent<NavMeshAgent>() == null)
        {
            nav = null;
            return;
        }
        nav = GetComponent<NavMeshAgent>();
        skinnedMeshRenderer = GetComponentInChildren<SkinnedMeshRenderer>();
        originColor = skinnedMeshRenderer.material.color;
    }
    private void Start()
    {
        if(enemyType == ENEMYTYPE.Gost2)
        {
            //gameObject.GetComponent<Collider>().enabled = false;
            nav.enabled = false;
        }
    }
    public void ApplyFlash(FlashMessage flashMessage)
    {
        if (flashMessage.isFlash) isLight = true;
    }
    void Update()
    {
        if(nav != null)
        {
            if (isLight)
            {
                nav.speed = 0;
                stopT += Time.deltaTime;
                skinnedMeshRenderer.material.color = Color.red;
                if (stopT > 5.0f)
                {
                    init();
                }
            }
            else if(!isLight)
            {
                if (enemyType == ENEMYTYPE.Gost2)
                {
                    target = PlayerController.Instance.gameObject;
                    transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * 0.8f);
                    Vector3 dir = target.transform.position - transform.position;
                    Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, Time.deltaTime * 2.0f, 0f);
                    transform.rotation = Quaternion.LookRotation(newDir);
                }
            }
            else
            {
                init();
            }
        }

        if (enemyType == ENEMYTYPE.Gost3)
        {
            target = PlayerController.Instance.gameObject;
            nav.SetDestination(target.transform.position);
        }
    }

    void init()
    {
        if (enemyType == ENEMYTYPE.Gost3) nav.speed = 0.6f;
        else nav.speed = 1.2f;
        stopT = 0f;
        isLight = false;
        skinnedMeshRenderer.material.color = originColor;
    }
}
