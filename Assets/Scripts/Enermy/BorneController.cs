using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorneController : MonoBehaviour
{
    public float speed;
    public float waitTime;//
    public Transform[] movePos;//�����ƶ���Χ
    public Animator animator;
    private int i = 0;
    private bool movingRight = true;
    private float wait;
    public int health;
    public int damage;
    public Transform target;//Ŀ��
    public float findistance = 6;//��ѰĿ�����
    public float radiusdistance = 1;//��������
    float y;
    // Start is called before the first frame update
    public void Start()
    {
        y = transform.position.y;
        wait = waitTime;
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
        animator.SetBool("Run", true);
        //�ƶ��ж�
        if (target)//�Ƿ��ҵ�����Ŀ��
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            if (distance < findistance)//�������Ŀ���ڹ�����Χ�⣬��Ŀ���ƶ�
            {
                //animator.SetBool("Attack", attack);
                //if(!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Attack")) animator.SetBool("Run", true);
                if (!animator.GetCurrentAnimatorClipInfo(0)[0].clip.name.Equals("Attack"))
                {
                    if (distance > radiusdistance)
                    {
                        animator.SetBool("Run", true);
                        transform.position = Vector2.MoveTowards(transform.position, new Vector2(target.position.x, y), speed * Time.deltaTime);
                    }
                    else
                    {
                        animator.SetTrigger("attack");
                        animator.SetBool("Run", false);
                    }
                }
                if (transform.position.x < target.position.x)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
            }
            else//�����ƶ�
            {
                transform.position = Vector2.MoveTowards(transform.position, movePos[i].position, speed * Time.deltaTime);

                if (Vector2.Distance(transform.position, movePos[i].position) < 0.1f)
                {
                    if (waitTime > 0)
                    {
                        waitTime -= Time.deltaTime;
                    }
                    else
                    {
                        if (movingRight)
                        {
                            transform.eulerAngles = new Vector3(0, -180, 0);
                            movingRight = false;
                        }
                        else
                        {
                            transform.eulerAngles = new Vector3(0, 0, 0);
                            movingRight = true;
                        }
                        if (i == 0)
                        {
                            i = 1;
                        }
                        else
                        {
                            i = 0;
                        }
                        waitTime = wait;
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