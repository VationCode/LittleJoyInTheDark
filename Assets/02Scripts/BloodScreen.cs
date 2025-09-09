using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class BloodScreen : MonoBehaviour
{
    [SerializeField]
    private PostProcessVolume m_post;

    private void Start()
    {
        m_post.enabled = false;
        Invoke("Effect", 15);
    }

    private void Effect()
    {
        m_post.enabled = true;
    }

}
