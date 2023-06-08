using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{


    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(gameObject, 3);
        if (other.CompareTag("Hero"))
        {
            Destroy(gameObject);
        }
    }

}