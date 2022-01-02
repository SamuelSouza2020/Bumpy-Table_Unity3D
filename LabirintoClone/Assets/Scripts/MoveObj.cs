using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObj : MonoBehaviour
{
    int lado = 0;

    private void Update()
    {
        if (transform.position.z <= 3.7 && lado == 0)
        {
            transform.Translate(new Vector3(0, 0, 4 * Time.deltaTime));
            if (transform.position.z >= 2.8)
            {
                lado = 1;
            }
        }
        if (transform.position.z >= -3.7 && lado == 1)
        {
            transform.Translate(new Vector3(0, 0, -4 * Time.deltaTime));
            if (transform.position.z <= -2.8)
            {
                lado = 0;
            }
        }
    }
}
