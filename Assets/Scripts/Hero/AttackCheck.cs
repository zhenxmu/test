using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public int currentDamageAmount; // 当前伤害值
    public double waitsecond;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enermy"))
        {
            // 对碰撞到的物体施加向右的力
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Take_Damage");

            //yield return new WaitForSeconds((float)waitsecond);

            GameObject bloodSplat = Instantiate(Resources.Load("BloodExplosion2D") as GameObject, other.transform.position, Quaternion.identity);
            // 减少敌人的生命值
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                enemyHealth.ChangeHealth(-currentDamageAmount);
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = Resources.Load<AudioClip>("etfx_explosion_rocket");
                audioSource.Play();
            }
            //yield return new WaitForSeconds(2f);
            StartCoroutine(blood_Destory(bloodSplat));
        }
        else if (other.CompareTag("green"))
        {

            // 对碰撞到的物体施加向右的力
            //other.attachedRigidbody.AddForce(Vector3.right * forceAmount, ForceMode2D.Impulse);
            Animator anim2 = other.GetComponent<Animator>();
            anim2.SetTrigger("Take_Damage");

            //yield return new WaitForSeconds((float)waitsecond);

            GameObject bloodSplat = Instantiate(Resources.Load("GreenBloodExplosion2D") as GameObject, other.transform.position, Quaternion.identity);
            // 减少敌人的生命值
            Health enemyHealth = other.GetComponent<Health>();
            if (enemyHealth != null)
            {
                AudioSource audioSource = GetComponent<AudioSource>();
                audioSource.clip = Resources.Load<AudioClip>("etfx_explosion_rocket");
                audioSource.Play();
                enemyHealth.ChangeHealth(-currentDamageAmount);

            }
            //yield return new WaitForSeconds(2f);
            StartCoroutine(blood_Destory(bloodSplat));
        }
    }
    IEnumerator blood_Destory(GameObject bloodSplat)
    {
        yield return new WaitForSeconds(2f);
        Destroy(bloodSplat);
    }
}
