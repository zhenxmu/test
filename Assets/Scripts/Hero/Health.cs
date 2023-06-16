using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    //生命值系统
    public int maxHealth;
    int currentHealth;
    public float death_time;
    
    public int health { get { return currentHealth; } }//属性返回当前生命值
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeHealth(int amount)//一个公开函数
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
                Debug.Log("主角等级" + AttackControl.level);
                Debug.Log("开始死亡");
            }
            if (gameObject.tag.Equals("Enermy"))
            {
                Destroy(gameObject);
                AttackControl.level += 1;
                Debug.Log("主角等级" + AttackControl.level);
                Debug.Log("开始死亡");
            }

        }
        
        Debug.Log(gameObject.tag+currentHealth + "/" + maxHealth);

    }
}
