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
  
    public float forceAmount = 1f; // ����ʩ�����Ĵ�С,����Ч��
    

    GameObject cdEmpty;//cd ui���ƿ�����

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
            StartCoroutine(ActivateTrigger(nomal, 0.2f)); // ����nomal GameObject�Ĵ�����1��
        }
        if (Input.GetKeyUp(KeyCode.K) && nowcd <= 0)
        {
            anim.SetTrigger("SkillAttack");
            StartCoroutine(ActivateTrigger(attack, 0.5f)); // ����attack GameObject�Ĵ�����1��
                                                           //���ܽ���cd
            nowcd = skillcd;

            cdEmpty.GetComponent<SkillController>().cdstart(nowcd);//��ʼcd
        }
        if (nowcd > 0)
        {
            nowcd -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

    }

    // ��ⴥ������ײ


    // �����������ָ��ʱ���ر�
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