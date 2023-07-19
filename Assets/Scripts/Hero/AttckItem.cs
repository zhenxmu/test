using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AttckItem : MonoBehaviour
{

    public GameObject fireballPrefab;
    public GameObject hero;

    void Start()
    {
        StartCoroutine(ShootFireball());
    }

    IEnumerator ShootFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            GameObject fireball = Instantiate(fireballPrefab, transform.position-new Vector3(2,0,0), Quaternion.identity);
            Vector2 direction = (hero.transform.position - transform.position).normalized;
            fireball.transform.forward = direction;
            Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();
            rb.AddForce(direction * 50f);
        }
    }

}
