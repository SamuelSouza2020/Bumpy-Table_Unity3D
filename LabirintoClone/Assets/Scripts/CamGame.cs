using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamGame : MonoBehaviour
{
    //BallD vai utilizar o ok para verificar se a camera já se posicionou
    public bool ok = false;
    float vel = 0.3f;

    // Update is called once per frame
    void Update()
    {
        if(!ok)
        {
            transform.position = Vector3.Lerp(transform.position, new Vector3(0, 15, 0), vel * Time.deltaTime);
            transform.eulerAngles = Vector3.Lerp(transform.eulerAngles, new Vector3(90, 0, 0), vel * Time.deltaTime);
            if(transform.position.y >= 9)
            {
                vel = 0.6f;
                if(transform.position.y >= 11)
                {
                    vel = 0.8f;
                }
            }
            if(transform.position.y >= 14.95)
            {
                ok = true;
            }
        }
    }
}
