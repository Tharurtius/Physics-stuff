using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{
    private Rigidbody[] manparts;

    // Start is called before the first frame update
    void Start()
    {
        manparts = gameObject.GetComponentsInChildren<Rigidbody>();
        
        foreach (Rigidbody part in manparts)
        {
            part.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
