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
}
