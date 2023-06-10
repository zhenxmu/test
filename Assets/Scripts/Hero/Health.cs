using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    //����ֵϵͳ
    public int maxHealth;
    int currentHealth;
    
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
