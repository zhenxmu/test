using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireController : MonoBehaviour
{
    public Animator animator;
    public GameObject fireballPrefab; // 火球预制体
    public float fireballSpeed = 5f; // 火球速度
    public float fireballInterval = 2f; // 发射火球的间隔时间
    private float lastFireballTime = 0f; // 上一次发射火球的时间
    public int health=20;
    public int damage;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("Attack", false);
        // 检查是否到了发射火球的时间
        if (Time.time - lastFireballTime > fireballInterval)
        {
            animator.SetBool("Attack", true);
            // 创建火球实例
            GameObject fireball = Instantiate(fireballPrefab, transform.position, Quaternion.identity);
            // 设置火球速度
            fireball.GetComponent<Rigidbody2D>().velocity = new Vector2(-fireballSpeed, 0);
            // 更新上一次发射火球的时间
            lastFireballTime = Time.time;

        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        //死亡判断
        if (health <= 0)
        {
            Destroy(gameObject);
        }

    }
}

