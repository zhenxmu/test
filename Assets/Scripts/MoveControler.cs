using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
        private Rigidbody2D rg;
        private Collider2D coll;
        private Animator anim;
    private SpriteRenderer sprite;

    //public GameObject lift;//托举物品
    //public float dis = 0;

    ////托举
    //public float hight = 3;
    //public Transform kid_transform;
    //public Transform box_transform;
    //生命值系统
    public int maxHealth ;
    int currentHealth;
    public int health { get { return currentHealth; } }//属性返回当前生命值

    //无敌时间
    public float timeInvincible = 2.0f;
        bool isInvincible;
        float invincibleTimer;
        

        public Transform groundcheck;
        public LayerMask ground;
        //跳跃控制
        public bool isGround, isJump;

        public bool jumpPressed;
        int jumpCount;
        //人的朝向
        float h = 0;

        bool walk = true;
        public float moveSpeed, jumpForce;
        float speed = 0;

        bool ispulling = false;
        void Start()
        {
            rg = GetComponent<Rigidbody2D>();
            coll = GetComponent<Collider2D>();
            anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
            //lift.SetActive(false);
            speed = moveSpeed;
        }

        // Update is called once per frame
        void Update()
        {
            // Debug.Log(rg.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && jumpCount > 0)
            {
                Debug.Log("按下了跳跃键");
                jumpPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.Space) && jumpCount > 0)
            {
                Debug.Log("松开跳跃键");
                jumpPressed = false;
            }

        if (isInvincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer < 0)
            {
                isInvincible = false;
            }
        }
        
        //下蹲
        //if (Input.GetKey(KeyCode.S))
        //{
        //    anim.SetBool("down", true);
        //    walk = false;
        //    if (kid_transform.position.y - box_transform.position.y > hight)
        //        lift.SetActive(true);
        //}
        //else
        //{
        //    anim.SetBool("down", false);
        //    walk = true;
        //    lift.SetActive(false);
        //}


    }

        private void FixedUpdate()
        {

        isGround = coll.IsTouchingLayers(ground);
        groundMovement();
        Jump();
        switchJump();

    }
    //左右移动逻辑
        void groundMovement()
        {

            if (walk)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    h = -1;
                    sprite.flipX = true;
                    anim.SetBool("Move", true);
                //加速
                    if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed=10;
                }
                else
                {
                    moveSpeed = speed;
                }

            }
                else if (Input.GetKey(KeyCode.D))
                {
                    h = 1;
                    anim.SetBool("Move", true);
                sprite.flipX = false;
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    moveSpeed =10;
                }
                else
                {
                    moveSpeed = speed;
                }
            }
                else
                {
                    h = 0;
                    anim.SetBool("Move", false);
                }
            }

        //rg.velocity = new Vector2(h * moveSpeed, rg.velocity.y);
        
        transform.Translate(Vector3.right * h * moveSpeed * Time.fixedDeltaTime);
        
        }
    //跳跃逻辑设置
        void Jump()
        {
        if (isGround)
        {
            jumpCount = 2;
            isJump = false;
        }

        if (jumpPressed && (isGround || (jumpCount > 0 && isJump)))
        {
            isJump = true;
            rg.velocity = new Vector2(rg.velocity.x, jumpForce);
            jumpCount--;

            if (!isGround)
            {
                anim.SetBool("jump", true);
            }

            jumpPressed = false;
        }

    }
    //跳跃动画的切换
        void switchJump()
        {
            if (isGround)
            {
                anim.SetBool("jump", false);
            }
            else if (!isGround && rg.velocity.y > 0)
            {
                anim.SetBool("jump", true);
            }
            else if (rg.velocity.y < 0 && !isGround)
            {
                anim.SetBool("jump", true);
            }
        }
    //血量控制的公开函数
    public void ChangeHealth(int amount)//一个公开函数
    {
        if (amount < 0)
        {
            if (isInvincible) return;

            isInvincible = true;
            invincibleTimer = timeInvincible;
        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(currentHealth + "/" + maxHealth);

    }

}
