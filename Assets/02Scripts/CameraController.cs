using System.Collections;
using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    CinemachineCamera m_freeLookCam;
    [SerializeField]
    CinemachineCamera m_mapScanCam;
    private void Start()
    {
        m_mapScanCam.Priority = 10;
        m_freeLookCam.Priority = 20;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void MapScan(float skillTime)
    {
        m_mapScanCam.Priority = 20;
        m_freeLookCam.Priority = 10;
        StartCoroutine(InitMapScanCoroutine(skillTime));
    }

    private IEnumerator InitMapScanCoroutine(float skillTime)
    {
        yield return new WaitForSeconds(skillTime);
        m_mapScanCam.Priority = 10;
        m_freeLookCam.Priority = 20;
    }
}
