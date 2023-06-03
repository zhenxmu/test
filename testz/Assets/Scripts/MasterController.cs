using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterController : MonoBehaviour
{
    public float speed;
    public Animator animator;
    public int health;
    public int damage;
    public Transform target;//Ä¿±ê
    public float findistance = 10;//ËÑÑ°Ä¿±ê¾àÀë
    public float radiusdistance = 0.5f;//¹¥»÷¾àÀë
    public float jumpSpeed;
    private Rigidbody2D myRigidbody;
    // Start is called before the first frame update
    public void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Hero").GetComponent<Transform>();
    }

    // Update is called once per frame
    public void Update()
    {
        if (target != null)
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            if (distance < findistance)
            {
                animator.SetBool("Run", true);
                animator.SetBool("Attack3", false);
                animator.SetBool("Attack4", false);
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
                if (transform.position.x < target.position.x)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (distance < radiusdistance)
                {
                    animator.SetBool("Run", false);
                    int randomInt = Random.Range(1, 4);
                    if (randomInt == 1)
                    {
                        animator.SetBool("Attack3", true);
                        animator.SetBool("Attack4", false);
                    }
                    else if (randomInt == 2)
                    {
                        animator.SetBool("Attack4", true);
                        animator.SetBool("Attack3", false);
                    }


                }
            }
            else
            {
                animator.SetBool("Run", false);
            }

        }
    }
    //ÊÜÉËº¦ÅÐ¶Ï
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetBool("Run", false);
        animator.SetBool("Damage", true);
        //ËÀÍöÅÐ¶Ï
        if (health <= 0)
        {
            animator.SetBool("Death", true);
            Destroy(gameObject);
        }

    }
}

