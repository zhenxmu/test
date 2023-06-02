using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class talk : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text talkinfo;
    string[] talklist = { };
    int talkcount = 0;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (talkcount >= talklist.Length)
            {
                
            }
            else
            {
                talkinfo.text = talklist[talkcount];
                talkcount++;
            }
        }
    }
}
