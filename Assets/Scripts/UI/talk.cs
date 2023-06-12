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
        talklist.Add(new Words(0, "你对我有意见吗？"));
        talklist.Add(new Words(1, "你对我有意见吗？"));
        talklist.Add(new Words(0, "你对我有意见吗？"));
        talklist.Add(new Words(1, "好的，我认为我们需要更多的合作和沟通。"));
        talklist.Add(new Words(1, "我同意你的观点，但是我认为现在我们需要先解决这个问题，然后再考虑如何加强合作和沟通。"));
        talklist.Add(new Words(0, "是的，这个问题确实很紧迫，但是我认为我们不能只是应急处理，而是要从根本上解决它。"));
        talklist.Add(new Words(0, "你说得对，我们需要彻底解决这个问题。那么你有什么想法吗？"));
        talklist.Add(new Words(0, "我认为我们需要制定一个详细的计划，并明确每个人的责任和角色。同时，我们也需要更频繁地开会，以确保大家都在同一个页面上。"));
        talklist.Add(new Words(1, "这听起来是个好主意。我们可以把我们的想法和建议整合起来，然后在下一次会议上讨论。好的，我会准备一份计划，并把它发给你们。我期待我们的下一次会议。”"));
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
