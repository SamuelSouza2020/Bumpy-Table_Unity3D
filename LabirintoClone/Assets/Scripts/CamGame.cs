using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CamGame : MonoBehaviour
{
    //BallD vai utilizar o ok para verificar se a camera já se posicionou
    public bool ok = false;
    float vel = 0.3f;
    float tempoSt = 5.5f, tempGO = 1.2f;

    GameObject canvasTP;
    Text tTempSt;

    private void Start()
    {
        tTempSt = GameObject.Find("TempoStart").GetComponent<Text>();
        canvasTP = GameObject.Find("CanvasTp");
    }

    // Update is called once per frame
    void Update()
    {
        if(tempGO > 0)
        {
            if (tempoSt > 0)
            {
                tempoSt -= Time.deltaTime;
                tTempSt.text = tempoSt.ToString("0");
            }
            else
            {
                tTempSt.text = "GO";
                tempGO -= Time.deltaTime;
                if (tempGO < 0.2)
                {
                    canvasTP.SetActive(false);
                }
            }
        }
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
