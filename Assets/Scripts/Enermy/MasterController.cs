using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public int health;
    public int damage;
    public Transform target;//目标
    public float findistance = 40;//搜寻目标距离
    public float radiusdistance = 5f;//攻击距离
    public float jumpSpeed;
    private Rigidbody2D myRigidbody;
    float y;

    public GameObject nomal;
    public GameObject attack;
   
    // Start is called before the first frame update
    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        y = transform.position.y;
    }
    // Update is called once per frame
    public void Update()
    {
        if (target != null)
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            if (distance < findistance)
            { 
                //animator.SetInteger("AnimState", 1);
                
                //如果当前状态不是攻击
                if(!(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Warlock_Spellcast") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Warlock_Attack")))
                {
                    
                    //左右转向
                    if (transform.position.x < target.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                    }
                    //如果到攻击范围内
                    if (distance < radiusdistance)
                    {
                        animator.SetInteger("AnimState", 0);
                        int randomInt = Random.Range(1, 3);
                        
                        if (randomInt >1)
                        {
                            animator.SetTrigger("Attack");
                            StartCoroutine(ActivateTrigger(nomal, 0.7f));
                        }
                        else if (randomInt == 1&& distance < 3.5f)
                        {
                            animator.SetTrigger("Spellcast");
                            StartCoroutine(ActivateTrigger(attack, 0.7f));
                        }
                    }
                    else//否则移动
                    {
                        animator.SetInteger("AnimState", 1);
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x,y), speed * Time.deltaTime);
                    }
                    
                }
            }
          
        }
    }
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
    //受伤害判断
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetBool("Run", false);
        animator.SetBool("Damage", true);
        //死亡判断
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject);
        }
    }
}

