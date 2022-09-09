using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineManager : MonoBehaviour
{
    public GameObject explosionPrefab;

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
        if (collision.transform.tag == "Ground")
        {
            return;//do nothing if touching ground
        }
        else if (collision.transform.tag == "Chassis")
        {
            Hitpoints.hp -= 50;
        }
        else if (collision.transform.tag == "Wheel")
        {
            Hitpoints.hp -= 25;
        }

        Explode();
    }

    public void Explode()
    {
        //physics
        Explosion.Explode(transform.position);
        //looks
        StartCoroutine(Boom(transform.position));
        //no more model
        Destroy(transform.GetChild(0).gameObject);
    }

    //visual stuff for explosion
    public IEnumerator Boom(Vector3 position)
    {
        Transform boom = Instantiate(explosionPrefab, position, Quaternion.identity).transform;
        float timer = 0.5f;
        while (timer > 0)
        {
            timer -= Time.deltaTime;
            boom.localScale *= 1.1f;
            yield return null;
        }
        Destroy(boom.gameObject);
        Destroy(gameObject);
    }
}
