using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadingScreen : MonoBehaviour
{
    public static LoadingScreen Instance { get; private set; }
    
    public Canvas canvas_loading;

    public Slider loadingBar;

    private void Awake()
    {
        Instance = this;
        canvas_loading.enabled = false;
    }

    public void LoadScene(string sceneName, float delay = 0f)
    {
        StartCoroutine(LoadSceneAsync(sceneName, delay));
    }

    IEnumerator LoadSceneAsync(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        canvas_loading.enabled = true;

        yield return null;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
        asyncLoad.allowSceneActivation = false;

        loadingBar.value = 0;

        // 씬 로딩이 완료될 때까지 기다림
        while (!asyncLoad.isDone)
        {
            // 로딩바 업데이트
            float progress = Mathf.Clamp01(asyncLoad.progress / Time.deltaTime);
            loadingBar.value = progress;
            yield return new WaitForSeconds(0.5f);
            if (progress >= 1) asyncLoad.allowSceneActivation = true;
        }
    }
}