using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

class Words
{
    public int who;
    public string word;
    
    public Words(int who,string word)
    {
        this.who = who;
        this.word = word;
    }
}
public class talk : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hero_talk;
    public GameObject boss_talk;

    public TMP_Text hero_talkinfo;
    public TMP_Text boss_talkinfo;
    int talkcount = 0;

    public GameObject hero;
    public GameObject boss;
    public GameObject help;

    public GameObject portal;

    List<Words> talklist = new List<Words>();
    // Update is called once per frame
    private void Start()
    {
        //0为主角，1为boss
        talklist.Add(new Words(0, "这里是你的梦境？好热闹的小镇……"));
        talklist.Add(new Words(1, "这里是我的家乡，达格利安郊外的一座小城镇……你是谁？！怎么会在我梦里！"));
        talklist.Add(new Words(0, "很抱歉，你已经秽蜕成碑魔了。"));
        talklist.Add(new Words(1, "碑魔……谁能告诉我为什么会这样？这些怪物是从哪里冒出来的？！"));
        talklist.Add(new Words(1, "我正在调查……艾默曼林分会的术士们还剩下多少人？"));
        talklist.Add(new Words(0, "我不知道，我好像一直镇守在这里……如果你要继续走下去……不要去碰那根石柱！"));
        //talklist.Add(new Words(0, "你说得对，我们需要彻底解决这个问题。那么你有什么想法吗？"));
        //talklist.Add(new Words(0, "我认为我们需要制定一个详细的计划，并明确每个人的责任和角色。同时，我们也需要更频繁地开会，以确保大家都在同一个页面上。"));
        //talklist.Add(new Words(1, "这听起来是个好主意。我们可以把我们的想法和建议整合起来，然后在下一次会议上讨论。好的，我会准备一份计划，并把它发给你们。我期待我们的下一次会议。”"));
    }
    void Update()
    {
        if ((boss.transform.position - hero.transform.position).sqrMagnitude<10)
        {
            help.SetActive(true);
            if (talkcount == 0)
            {
                if (Input.GetKeyDown(KeyCode.E)){
                    if (talklist[talkcount].who == 0)
                    {
                        boss_talk.SetActive(false);
                        hero_talk.SetActive(true);
                        hero_talkinfo.text = talklist[talkcount].word;
                        ++talkcount;
                    }
                    else if (talklist[talkcount].who == 1)
                    {
                        boss_talk.SetActive(true);
                        hero_talk.SetActive(false);
                        boss_talkinfo.text = talklist[talkcount].word;
                        ++talkcount;
                    }
                }
            }
            else if (Input.GetMouseButtonDown(0)|| Input.GetKeyDown(KeyCode.E))
            {
                if (talkcount >= talklist.Count)
                {
                    boss_talk.SetActive(false);
                    hero_talk.SetActive(false);
                    talkcount = 0;
                    portal.SetActive(true);
                }
                else
                {
                    if (talklist[talkcount].who == 0)
                    {
                        boss_talk.SetActive(false);
                        hero_talk.SetActive(true);
                        hero_talkinfo.text = talklist[talkcount].word;
                        ++talkcount;
                    }
                    else if (talklist[talkcount].who == 1)
                    {
                        boss_talk.SetActive(true);
                        hero_talk.SetActive(false);
                        boss_talkinfo.text = talklist[talkcount].word;
                        ++talkcount;
                    }
                }
            }
        }
        else
        {
            help.SetActive(false);
            boss_talk.SetActive(false);
            hero_talk.SetActive(false);
            talkcount = 0;
        }
    }

}
