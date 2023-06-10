using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //生命值系统
    public int maxHealth;
    int currentHealth;
    
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
                SceneManager.LoadScene("StartScene");
            }
            if (gameObject.name.Equals("Warlock"))
            {
                SceneManager.LoadScene("OldTown");
            }
            Destroy(gameObject);

        }
        
        Debug.Log(gameObject.tag+currentHealth + "/" + maxHealth);

    }
}
