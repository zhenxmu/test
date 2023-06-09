using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MasterController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public int health;
    public int damage;
    public Transform target;//Ŀ��
    public float findistance = 40;//��ѰĿ�����
    public float radiusdistance = 5f;//��������
    public float jumpSpeed;
    private Rigidbody2D myRigidbody;
    float y;

    public Slider hp;
    public GameObject hpcontainer;
    bool ishp;
    // Start is called before the first frame update
    public void Start()
    {
        hp.maxValue = GetComponent<Health>().maxHealth;
        ishp = false;

        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
        y = transform.position.y;
    }

    // Update is called once per frame
    public void Update()
    {
        if(ishp)hp.value = GetComponent<Health>().health;
        if (target != null)
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            if (distance < findistance)
            { 
                //animator.SetInteger("AnimState", 1);
                hpcontainer.SetActive(true);
                ishp = true;
                //�����ǰ״̬���ǹ���
                if(!(animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Warlock_Spellcast") || animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Warlock_Attack")))
                {
                    //����ת��
                    if (transform.position.x < target.position.x)
                    {
                        transform.eulerAngles = new Vector3(0, 0, 0);
                    }
                    else
                    {
                        transform.eulerAngles = new Vector3(0, -180, 0);
                    }
                    //�����������Χ��
                    if (distance < radiusdistance)
                    {
                        animator.SetInteger("AnimState", 0);
                        int randomInt = Random.Range(1, 4);
                        if (randomInt >1)
                        {
                            animator.SetTrigger("Attack");
                        }
                        else if (randomInt == 1)
                        {
                            animator.SetTrigger("Spellcast");
                        }
                    }
                    else//�����ƶ�
                    {
                        animator.SetInteger("AnimState", 1);
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x,y), speed * Time.deltaTime);
                    }
                    
                }
                
            }
          

        }
    }
    //���˺��ж�
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetBool("Run", false);
        animator.SetBool("Damage", true);
        //�����ж�
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject);
        }

    }
}

