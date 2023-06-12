using System.Collections;
using UnityEngine;
//**********
//����
//**********
public class AttackControl : MonoBehaviour
{
    public static Animator anim;
    public float skillcd=0;
    private float nowcd;
    public GameObject nomal;
    public GameObject attack;
  
    public float forceAmount = 1f; // ����ʩ�����Ĵ�С,����Ч��
    
    GameObject cdEmpty;//cd ui���ƿ�����

    private double waitsecond;

    bool is_attack=false;

    //��Ч����
    public static int level = 2;

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
        if (!is_attack)
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                waitsecond = 0.25;
                anim.SetTrigger("NomalAttack");
                StartCoroutine(ActivateTrigger(nomal, 0.5f)); // ����nomal GameObject�Ĵ�����0.5��
                StartCoroutine(ActivateAttack(0.25f));
            }
            if (Input.GetKeyUp(KeyCode.K) && nowcd <= 0)
            {
                anim.SetTrigger("SkillAttack");
                waitsecond = 1;
                StartCoroutine(ActivateTrigger(attack, 1f)); // ����attack GameObject�Ĵ�����1��
                                                             //���ܽ���cd
                nowcd = skillcd;

                cdEmpty.GetComponent<SkillController>().cdstart(nowcd);//��ʼcd
            }
        }
        
        if (nowcd > 0)
        {
            nowcd -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {

    }
    //****************************************************************
    // ��ⴥ������ײ
    //****************************************************************
    private IEnumerator ActivateAttack(float duration)//������Ч
    {
        yield return new WaitForSeconds(duration);
        for (int i = 0; i < level; i++)
        {
            Vector3 offset = new Vector3(i * 0.1f, i * 0.1f, 0); // adjust the offset as needed
            GameObject bloodSplat = Instantiate(Resources.Load("SwordHitBlueLegacy") as GameObject, nomal.transform.position + offset, Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
            Destroy(bloodSplat);
        }
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = Resources.Load<AudioClip>("etfx_explosion_lightning");
        audioSource.Play();


    }
    // �����������ָ��ʱ���ر�
    private IEnumerator ActivateTrigger(GameObject triggerObject, float duration)
    {
        is_attack = true;
        yield return new WaitForSeconds(duration);

        triggerObject.SetActive(true);
        is_attack = false;
        StartCoroutine(CloseTrigger(triggerObject));
        //triggerObject.SetActive(false);
    }
    private IEnumerator CloseTrigger(GameObject triggerObject)
    {

        yield return new WaitForSeconds(0.3f);

        triggerObject.SetActive(false);
    }
    public IEnumerator ToDeath()
    {
        anim.SetTrigger("Death");
        is_attack = true;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}