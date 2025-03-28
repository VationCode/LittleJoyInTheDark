using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float rotYSpeed;
    float XAxis;

    private void LateUpdate()
    {
        XAxis -= Input.GetAxis("Mouse Y") * rotYSpeed;
        XAxis = Mathf.Clamp(XAxis, -30, 60);
        PlayerController.Instance.camView.transform.eulerAngles = new Vector3(XAxis, PlayerController.Instance.camView.transform.eulerAngles.y, PlayerController.Instance.camView.transform.eulerAngles.z);
        //RayToPlayer();
    }

    void RayToPlayer()
    {
        Vector3 pos = PlayerController.Instance.gameObject.transform.position;
        Vector3 dir = new Vector3(pos.x, pos.y + 0.5f, pos.z) - transform.position;
        float dis = Vector3.Distance(transform.position, pos);
        RaycastHit[] hits = Physics.RaycastAll(transform.position, dir, dis, ~LayerMask.GetMask("Player"));
        
    }


}
