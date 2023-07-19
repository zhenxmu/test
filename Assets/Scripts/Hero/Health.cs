using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //����ֵϵͳ
    public int maxHealth;
    int currentHealth;
    public float death_time;
    
    public int health { get { return currentHealth; } }//���Է��ص�ǰ����ֵ
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeHealth(int amount)//һ����������
    {
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        if (currentHealth <= 0)
        {
            if (gameObject.tag.Equals("Hero"))
            {
                StartCoroutine(this.GetComponent<AttackControl>().ToDeath());
                SceneManager.LoadScene("DeathScene");
            }
            if (gameObject.name.Equals("Warlock"))
            {
                StartCoroutine(this.GetComponent<MasterController>().ToDeath(1.3f));
                AttackControl.level += 2;
                Debug.Log("���ǵȼ�" + AttackControl.level);
                Debug.Log("��ʼ����");
            }
            if (gameObject.tag.Equals("Enermy"))
            {
                Destroy(gameObject);
                AttackControl.level += 1;
                Debug.Log("���ǵȼ�" + AttackControl.level);
                Debug.Log("��ʼ����");
            }

        }
        
        Debug.Log(gameObject.tag+currentHealth + "/" + maxHealth);

    }
}
