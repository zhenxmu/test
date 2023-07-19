using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class SkillController : MonoBehaviour
{
    public GameObject skillcd;
    public GameObject skillclick;
    public TMP_Text cd;
    float cdtime;
    float hightlight_time = 0.1f;
    float time_cout;
    bool click = false;

    public void cdstart(float cd)
    {
        cdtime = cd;
    }
    public void clickSkill()
    {
        click = true;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            clickSkill();
        }

        if (cdtime > 0)
        {
            skillcd.SetActive(true);
            cdtime -= Time.deltaTime;
            cd.text = cdtime.ToString().Substring(0,3);
        }
        if(cdtime < 0)
        {
            cdtime = 0;
            skillcd.SetActive(false);
        }

        if (click)
        {
            skillclick.SetActive(true);
            time_cout = 0;
            click = false;
        }

        if(time_cout> hightlight_time)
        {
            skillclick.SetActive(false);
        }
        else
        {
            time_cout+=Time.deltaTime;
        }
    }
}
