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
    public int nomalDamageAmount = -5; // 设置nomal伤害值
    public int skillDamageAmount = -10; // 设置skill伤害值
    private int currentDamageAmount; // 当前伤害值

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
            StartCoroutine(ActivateTrigger(nomal, 0.5f)); // 激活nomal GameObject的触发器1秒
        }
        if (Input.GetKeyUp(KeyCode.K) && nowcd <= 0)
        {
            anim.SetTrigger("SkillAttack");
            currentDamageAmount = skillDamageAmount;
            StartCoroutine(ActivateTrigger(attack, 0.5f)); // 激活attack GameObject的触发器1秒
                                                           //技能进入cd
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

    // 检测触发器碰撞
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enermy"))
        {
            // 对碰撞到的物体施加向右的力
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Attacked");
          
            // 减少敌人的生命值
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(currentDamageAmount);
            }
        }
    }

    // 激活触发器并在指定时间后关闭
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