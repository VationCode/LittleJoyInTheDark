using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private AudioManager m_audioManager;

    [Header( "[ Dead Config ]" )]
    [SerializeField] private float m_fadeDuration = 3;

    public bool IsDead;
    private void Awake()
    {
        if ( Instance == null )
        {
            Instance = this;
            DontDestroyOnLoad( this );
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    
    public void PlayerDead()
    {
        if (IsDead) return;
        IsDead = true;
        // 사운드 효과
        m_audioManager.PlayGameOverSound();

        // DeadUI FadeIn
        UIManager.Instance.DeadUIFade(m_fadeDuration);

        // 현재 씬 재 로드
        Invoke("DelaySceneLoad", m_fadeDuration + 2f);
    }
    private void DelaySceneLoad()
    {
        SceneLoader.ReLoadCurrentScene();
        IsDead = false;
    }
    private void Ending()
    {
        SceneLoader.LoadScene(SceneType.CreditScene);
    }
}
