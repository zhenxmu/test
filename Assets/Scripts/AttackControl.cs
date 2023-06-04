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
    public int nomalDamageAmount = -5; // ����nomal�˺�ֵ
    public int skillDamageAmount = -10; // ����skill�˺�ֵ
    private int currentDamageAmount; // ��ǰ�˺�ֵ

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        nomal.SetActive(false);
        attack.SetActive(false);
        nowcd = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J))
        {
            anim.SetTrigger("NomalAttack");
            currentDamageAmount = nomalDamageAmount;
            StartCoroutine(ActivateTrigger(nomal, 0.5f)); // ����nomal GameObject�Ĵ�����1��
        }
        if (Input.GetKeyUp(KeyCode.K) && nowcd <= 0)
        {
            anim.SetTrigger("SkillAttack");
            currentDamageAmount = skillDamageAmount;
            StartCoroutine(ActivateTrigger(attack, 0.5f)); // ����attack GameObject�Ĵ�����1��
                                                           //���ܽ���cd
            nowcd = skillcd;
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
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enermy"))
        {
            // ����ײ��������ʩ�����ҵ���
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Attacked");
          
            // ���ٵ��˵�����ֵ
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(currentDamageAmount);
            }
        }
    }

    // �����������ָ��ʱ���ر�
    private IEnumerator ActivateTrigger(GameObject triggerObject, float duration)
    {
        triggerObject.SetActive(true);
        
        yield return new WaitForSeconds(duration);

        triggerObject.SetActive(false);
    }
    private IEnumerator wait( float duration)
    {
       

        yield return new WaitForSeconds(duration);

       
    }
}