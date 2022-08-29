using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashCode : MonoBehaviour
{
    [SerializeField] private GameObject electricity;
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
        if (collision.transform.root.tag == "Ragdoll")
        {
            CharacterJoint cj;
            float score = 0;
            Rigidbody[] manparts = collision.transform.root.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody part in manparts)
            {
                //part.isKinematic = false;
                part.useGravity = true;
                if (!part.TryGetComponent<CharacterJoint>(out cj)) continue;
                score += cj.currentForce.sqrMagnitude;
            }
            if (GameManager.scored == false)
            {
                //score calcs
                GameManager.score += score * 0.01f * Hitpoints.hp * 0.01f;
                //bonus score for full hp
                GameManager.score += Hitpoints.hp == 100 ? 1000 : 0;
                //only score once
                GameManager.scored = true;
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.transform.root.tag == "Danger")
        {
            //debug shit
            //Debug.Log(other.transform.name);
            if (!electricity.activeSelf)
            {
                electricity.SetActive(true);
            }
            Hitpoints.hp -= Time.deltaTime * 5;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (electricity.activeSelf)
        {
            electricity.SetActive(false);
        }
    }
}
