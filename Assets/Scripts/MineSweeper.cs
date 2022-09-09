using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineSweeper : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 30f))
            {
                if (hit.transform.tag == "Mine")
                {
                    hit.transform.GetComponent<MineManager>().Explode();
                }
            }
        }
    }
}
