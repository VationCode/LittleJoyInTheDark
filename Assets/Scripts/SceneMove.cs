using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMove : MonoBehaviour
{
    public string nextSceneName;

    bool isMoving = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!isMoving && other.transform == PlayerController.Instance.transform)
        {
            isMoving = true;
            LoadingScreen.Instance.LoadScene(nextSceneName, 0.2f);
        }
    }
}
