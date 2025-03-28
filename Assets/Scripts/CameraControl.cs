using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CameraControl : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject topCamera;
    public TextMeshProUGUI skill;
    public TextMeshProUGUI time;
    float coolTime = 3.0f;
    int skillCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        //mainCamera.SetActive(true);
        //topCamera.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*        if (skillCount > 0 &&coolTime<=0)
                {
                    if (Input.GetKeyDown(KeyCode.C))
                    {
                        SwitchCamera();
                    }

                    if (Input.GetKeyDown(KeyCode.R))
                    {
                        SwitchCameraMove();
                    }
                    skillCount--;
                    coolTime = 3;
                }*/

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (skillCount > 0 && coolTime <= 0)
            {

                SwitchCamera();
                skillCount--;
                coolTime = 3;
            }
            else
            {
                Debug.Log("SkillCount:"+skillCount+"  CoolTime:"+coolTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SwitchCameraMove();
                skillCount--;
                coolTime = 3;
            }
            else
            {
                Debug.Log("SkillCount:" + skillCount + "  CoolTime:" + coolTime);
            }
        }

    }

    private void Update()
    {
        if (coolTime > 0)
            coolTime -= Time.deltaTime;
        else
            coolTime = 0;
        skill.GetComponent<TextMeshProUGUI>().text = "Skill : " + skillCount;
        time.GetComponent<TextMeshProUGUI>().text = "Time : " + coolTime;

    }


    void SwitchCamera()
    {
        if (mainCamera.activeSelf==true)
        {
            mainCamera.SetActive(false);
            topCamera.SetActive(true);
        }
        else
        {
            mainCamera.SetActive(true);
            topCamera.SetActive(false);
        }

    }

    void SwitchCameraMove()
    {

    }
}
