using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;
    public GameObject fireballPrefab; // ����Ԥ����
    public float fireballSpeed = 5f; // �����ٶ�
    public float fireballInterval = 2f; // �������ļ��ʱ��
    private float lastFireballTime = 0f; // ��һ�η�������ʱ��
    public int health=20;
    public int damage;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Attack", false);
        // ����Ƿ��˷�������ʱ��
        if (Time.time - lastFireballTime > fireballInterval)
        {
            animator.SetBool("Attack", true);
            // ��������ʵ��
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            // ���û����ٶ�
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireballSpeed, 0);
            // ������һ�η�������ʱ��
            lastFireballTime = Time.time;

        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //�����ж�
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}

