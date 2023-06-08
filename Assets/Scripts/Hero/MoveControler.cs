using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveControler : MonoBehaviour
{
        private Rigidbody2D rg;
        private Collider2D coll;
        private Animator anim;
    private SpriteRenderer sprite;

    //public GameObject lift;//�о���Ʒ
    //public float dis = 0;

    ////�о�
    //public float hight = 3;
    //public Transform kid_transform;
    //public Transform box_transform;
    //����ֵϵͳ
    public int maxHealth ;
    int currentHealth;
    public int health { get { return currentHealth; } }//���Է��ص�ǰ����ֵ

    //�޵�ʱ��
    public float timeInvincible = 2.0f;
        bool isInvincible;
        float invincibleTimer;
        

        public Transform groundcheck;
        public LayerMask ground;
        //��Ծ����
        public bool isGround, isJump;

        public bool jumpPressed;
        int jumpCount;
        //�˵ĳ���
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
                Debug.Log("��������Ծ��");
                jumpPressed = true;
            }
            if (Input.GetKeyUp(KeyCode.Space) && jumpCount > 0)
            {
                Debug.Log("�ɿ���Ծ��");
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
        
        //�¶�
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
    //�����ƶ��߼�
        void groundMovement()
        {

            if (walk)
            {
                if (Input.GetKey(KeyCode.A))
                {
                    h = -1;
                    sprite.flipX = true;
                    anim.SetBool("Move", true);
                //����
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
    //��Ծ�߼�����
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
    //��Ծ�������л�
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
    //Ѫ�����ƵĹ�������
    public void ChangeHealth(int amount)//һ����������
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
