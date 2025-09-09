using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum SceneType
{
    Title,
    Lobby,
    InGame,
    InGame2,
    CreditScene
}

public class SceneLoader
{
    public static void LoadScene(SceneType sceneType)
    {
        //LoadingScreen.Instance.LoadScene(sceneType.ToString(), 0.2f);
        SceneManager.LoadScene(sceneType.ToString());
    }
    public static void ReLoadCurrentScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
