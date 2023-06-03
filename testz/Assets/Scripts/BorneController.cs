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
    public bool attack;
    // Start is called before the first frame update
    public void Start()
    {
        wait = waitTime;
        animator = GetComponent<Animator>();
    }
    private void OnTriggerStay2D(Collider2D other)//����Ŀ���ж�
    {
        if (Vector2.Distance(other.transform.position, transform.position) <= findistance)//�����ײ�����С����ѰĿ�����
        {
            if (target)
            {

            }
            else
            {
                if (other.gameObject.tag == "Player")
                    target = other.transform;
            }

        }
    }

    // Update is called once per frame
    public void Update()
    {
        animator.SetBool("Run", true);
        //�ƶ��ж�
        attack = false;
        if (target)//�Ƿ��ҵ�����Ŀ��
        {

            if (Vector2.Distance(target.position, transform.position) > radiusdistance)//�������Ŀ���ڹ�����Χ�⣬��Ŀ���ƶ�
            {
                animator.SetBool("Attack", attack);
                animator.SetBool("Run", true);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (transform.position.x < target.position.x)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
            }
            else//�ڹ�����Χ�ڣ�����Ŀ��
            {
                attack = true;
                animator.SetBool("Attack", attack);
                animator.SetBool("Run", false);
            }
        }
        else//û�ҵ�����Ŀ�꣬�������ƶ�
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