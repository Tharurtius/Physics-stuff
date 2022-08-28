using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clickexplode : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosiveForce;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1)) //right click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            
            Debug.DrawRay(ray.origin, ray.direction, Color.red, 1f);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //we hit something

                Collider[] withinExplosion = Physics.OverlapSphere(hit.point, _explosionRadius);

                foreach (Collider coll in withinExplosion)
                {
                    Rigidbody rb;
                    //3 different ways to do the same thing
                    //1: if (rb == null) continue;
                    //2: if (!coll.TryGetComponent<Rigidbody>(out rb)) continue;
                    /*3: try
                    {
                        rb = coll.GetComponent<Rigidbody>();
                    }
                    catch
                    {
                        continue;
                    }*/
                    if (!coll.TryGetComponent<Rigidbody>(out rb)) continue;
                    Vector3 direction = (coll.transform.position - hit.point);
                    float sqrMag = direction.sqrMagnitude;
                    Vector3 finalForce = direction.normalized *(_explosiveForce / sqrMag);
                    rb.AddForce(finalForce, ForceMode.Impulse);
                    
                    //rb.AddExplosionForce(_explosiveForce, hit.point, _explosionRadius);
                }
            }
            //if ray hits nothing, returns false
        }
    }
}
