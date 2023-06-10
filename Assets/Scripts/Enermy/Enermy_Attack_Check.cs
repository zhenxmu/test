using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enermy_Attack_Check : MonoBehaviour
{
    public int currentDamageAmount; // ��ǰ�˺�ֵ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Hero"))
        {
            // ����ײ��������ʩ�����ҵ���
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Take_Damage");

            // ���ٵ��˵�����ֵ
            Health heroHealth = other.GetComponent<Health>();
            if (heroHealth != null)
            {
                heroHealth.ChangeHealth(-currentDamageAmount);
            }
        }
    }

}
