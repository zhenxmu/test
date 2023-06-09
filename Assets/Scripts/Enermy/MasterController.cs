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

    public GameObject nomal;
    public GameObject attack;
    public GameObject hp;
    public Slider hp_slider;

    public GameObject portal;

    bool being_death=false;
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
        if (hp.activeSelf)
        {
            hp_slider.maxValue = gameObject.GetComponent<Health>().maxHealth;
            hp_slider.value = gameObject.GetComponent<Health>().health;
        }
        if (being_death)
        {
            return;
        }
        
        if (target != null)
        {
            float distance = (transform.position - target.position).sqrMagnitude;
            if (distance < findistance)
            {
                //animator.SetInteger("AnimState", 1);
                hp.SetActive(true);
                
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
                    else//�����ƶ�
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
    //���˺��ж�
    public IEnumerator ToDeath(float duration)
    {
        animator.SetTrigger("Death");
        being_death = true;
        yield return new WaitForSeconds(duration);
        portal.SetActive(true);
        Vector3 po = this.transform.position;
        po.y += 1.2f;
        portal.transform.position = po;
        Destroy(gameObject);
    }
}

