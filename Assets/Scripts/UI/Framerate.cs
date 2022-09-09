using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Framerate : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //if there is no target framerate, set fr to first dropdown value
        if (Application.targetFrameRate == -1)
        {
            Application.targetFrameRate = 60;
        }
        //if framerate not default value, set dropdown value to proper setting
        if (Application.targetFrameRate == 120)
        {
            GetComponent<Dropdown>().value = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeFrameRate(int input)
    {
        //Debug.Log(input);
        Application.targetFrameRate = input == 0 ? 60 : 120;
    }
}
