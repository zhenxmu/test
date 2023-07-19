using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    //�����˺�ϵͳ
   
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            Health heroHealth = other.GetComponent<Health>();
            if (heroHealth != null)
            {
                heroHealth.ChangeHealth(-5);
            }
        }
    }
}
