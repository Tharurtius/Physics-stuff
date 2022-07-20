using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCode : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.name);
        Rigidbody[] manparts = collision.gameObject.transform.root.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody part in manparts)
        {
            part.isKinematic = false;
        }
    }
}
