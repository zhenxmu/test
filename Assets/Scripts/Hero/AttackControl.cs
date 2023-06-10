using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    public static Animator anim;
    public float skillcd=0;
    private float nowcd;
    public GameObject nomal;
    public GameObject attack;
  
    public float forceAmount = 1f; // 设置施加力的大小,击退效果
    

    GameObject cdEmpty;//cd ui控制空物体

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nomal.SetActive(false);
        attack.SetActive(false);
        nowcd = 0;

        cdEmpty = GameObject.Find("cdEmpty");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("NomalAttack");
            StartCoroutine(ActivateTrigger(nomal, 0.2f)); // 激活nomal GameObject的触发器1秒
        }
        if (Input.GetKeyUp(KeyCode.K) && nowcd <= 0)
        {
            anim.SetTrigger("SkillAttack");
            StartCoroutine(ActivateTrigger(attack, 0.5f)); // 激活attack GameObject的触发器1秒
                                                           //技能进入cd
            nowcd = skillcd;

            cdEmpty.GetComponent<SkillController>().cdstart(nowcd);//开始cd
        }
        if (nowcd > 0)
        {
            nowcd -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

    }

    // 检测触发器碰撞


    // 激活触发器并在指定时间后关闭
    private IEnumerator ActivateTrigger(GameObject triggerObject, float duration)
    {

        yield return new WaitForSeconds(duration);

        triggerObject.SetActive(true);
        StartCoroutine(CloseTrigger(triggerObject));
        //triggerObject.SetActive(false);
    }
    private IEnumerator CloseTrigger(GameObject triggerObject)
    {

        yield return new WaitForSeconds(0.3f);

        triggerObject.SetActive(false);
    }
}