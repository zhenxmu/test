using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentDamageAmount; // ��ǰ�˺�ֵ
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enermy"))
        {
            // ����ײ��������ʩ�����ҵ���
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Take_Damage");

            // ���ٵ��˵�����ֵ
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-currentDamageAmount);
            }
        }
    }
}
