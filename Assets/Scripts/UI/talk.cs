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
        //0Ϊ���ǣ�1Ϊboss
        talklist.Add(new Words(0, "����������ξ��������ֵ�С�򡭡�"));
        talklist.Add(new Words(1, "�������ҵļ��磬������������һ��С���򡭡�����˭������ô���������"));
        talklist.Add(new Words(0, "�ܱ�Ǹ�����Ѿ����ɳɱ�ħ�ˡ�"));
        talklist.Add(new Words(1, "��ħ����˭�ܸ�����Ϊʲô����������Щ�����Ǵ�����ð�����ģ���"));
        talklist.Add(new Words(1, "�����ڵ��顭����Ĭ���ַֻ����ʿ�ǻ�ʣ�¶����ˣ�"));
        talklist.Add(new Words(0, "�Ҳ�֪�����Һ���һֱ����������������Ҫ��������ȥ������Ҫȥ���Ǹ�ʯ����"));
        //talklist.Add(new Words(0, "��˵�öԣ�������Ҫ���׽��������⡣��ô����ʲô�뷨��"));
        //talklist.Add(new Words(0, "����Ϊ������Ҫ�ƶ�һ����ϸ�ļƻ�������ȷÿ���˵����κͽ�ɫ��ͬʱ������Ҳ��Ҫ��Ƶ���ؿ��ᣬ��ȷ����Ҷ���ͬһ��ҳ���ϡ�"));
        //talklist.Add(new Words(1, "���������Ǹ������⡣���ǿ��԰����ǵ��뷨�ͽ�������������Ȼ������һ�λ��������ۡ��õģ��һ�׼��һ�ݼƻ����������������ǡ����ڴ����ǵ���һ�λ��顣��"));
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
