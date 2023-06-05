using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
        if (currentHealth <= 0)
        {
            Destroy(gameObject);

        }
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        Debug.Log(gameObject.tag+currentHealth + "/" + maxHealth);

    }
}
