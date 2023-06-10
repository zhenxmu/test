using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentDamageAmount; // 当前伤害值
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enermy"))
        {
            // 对碰撞到的物体施加向右的力
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Take_Damage");

            // 减少敌人的生命值
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-currentDamageAmount);
            }
        }
    }
}
