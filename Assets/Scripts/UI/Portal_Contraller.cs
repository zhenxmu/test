using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal_Contraller : MonoBehaviour
{
    public GameObject portal;
    public TMP_Text press_E;
    public string scene_name;
    public string press_E_;
    bool isopen=false;
    // Start is called before the first frame update
    private void Update()
    {
        if (isopen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene(scene_name);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag.Equals("Hero"))
        {
            isopen = true;
            press_E.text = press_E_;
        }
        
        
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag.Equals("Hero"))
        {
            isopen = false;
            press_E.text = "";
        }
            
    }
}
