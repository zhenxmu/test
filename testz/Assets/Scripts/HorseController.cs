using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseController : MonoBehaviour
{
    public float speed;
    public float waitTime;
    public Transform[] movePos;
    public int health;
    public int damage;
    private int i = 0;
    private bool movingRight = true;
    private float wait;

    // Start is called before the first frame update
    public void Start()
    {
        wait = waitTime;
    }

    // Update is called once per frame
    public void Update()
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
