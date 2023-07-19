using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HMPController : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider hp;
    public Slider mp;
    public Slider san;
    public GameObject Hero;
    void Start()
    {
        hp.maxValue = Hero.GetComponent<Health>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        hp.value = Hero.GetComponent<Health>().health;
    }
}
