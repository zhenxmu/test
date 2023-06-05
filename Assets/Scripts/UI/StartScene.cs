using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    public GameObject startmenu;
    public GameObject setmenu;
    public TMP_Text v;
    public int voice = 5;
    public GameObject background;
    float move_time;
    public float backmovspeed=1.0f;
    public void gameStart()
    {
        SceneManager.LoadScene("InfoScene");
    }
    public void close()
    {
        startmenu.SetActive(true);
        setmenu.SetActive(false);
    }
    public void setting()
    {
        startmenu.SetActive(false);
        setmenu.SetActive(true);
    }
    public void addVoice()
    {
        if (voice < 10)
        {
            voice++;
            v.text = voice + "";
        }
    }
    public void subtractVoice()
    {
        if (voice > 0)
        {
            voice--;
            v.text = voice + "";
        }
    }

    int movdir = 0; 
    private void Update()
    {
        Vector3 po = background.transform.position;
        if(movdir == 0)
        {
            po.x+=Time.deltaTime*100*backmovspeed;
            po.y+=Time.deltaTime*60 * backmovspeed;
            move_time+=Time.deltaTime;
            if (move_time > 2)
            {
                move_time = 0;
                movdir = 1;
            }
        }
        else if (movdir == 1)
        {
            po.x += Time.deltaTime * 60 * backmovspeed;
            po.y -= Time.deltaTime * 100 * backmovspeed;
            move_time += Time.deltaTime;
            if (move_time > 2)
            {
                move_time = 0;
                movdir = 2;
            }
        }
        else if (movdir == 2)
        {
            po.x -= Time.deltaTime * 120 * backmovspeed;
            po.y -= Time.deltaTime * 60 * backmovspeed;
            move_time += Time.deltaTime;
            if (move_time > 2)
            {
                move_time = 0;
                movdir = 3;
            }
        }
        else if (movdir == 3)
        {
            po.x -= Time.deltaTime * 60 * backmovspeed;
            po.y += Time.deltaTime * 100 * backmovspeed;
            move_time += Time.deltaTime;
            if (move_time > 2)
            {
                move_time = 0;
                movdir = 0;
            }
        }
        background.transform.position = po;
    }
}
