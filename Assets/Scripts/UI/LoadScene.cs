using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public float speed=1;
    public TMP_Text text;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)||Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Forest");
        }
        Vector3 v=text.transform.position;
        v.y+=speed*Time.deltaTime;
        text.transform.position = v;
    }
}
