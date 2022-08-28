using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion
{
    [SerializeField] public static float _explosionRadius;
    [SerializeField] public static float _explosiveForce;
    public static void Explode(Vector3 position)
    {
        Collider[] withinExplosion = Physics.OverlapSphere(position, _explosionRadius);

        foreach (Collider coll in withinExplosion)
        {
            Rigidbody rb;
            if (!coll.TryGetComponent<Rigidbody>(out rb)) continue;
            Vector3 direction = (coll.transform.position - position);
            float sqrMag = direction.sqrMagnitude;
            Vector3 finalForce = direction.normalized * (_explosiveForce / sqrMag);
            rb.AddForce(finalForce, ForceMode.Impulse);
        }
    }
}
