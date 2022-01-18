using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CamGame : MonoBehaviour
{
    //Todos os comandos são encontrados no Unity Documentation
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
    void Update()
    {
        //Caso o player aperte o botão voltar do smartphone para sair do jogo
        if(Input.GetKeyDown(KeyCode.Escape) && OndeEstou.instance.fase == 0)
        {
            Application.Quit();
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && OndeEstou.instance.fase != 0)
        {
            SceneManager.LoadScene(0);
        }
        //Tempo para posicionar a câmera
        if(tempGO > 0)
        {
            if (tempoSt > 0)
            {
                //Aqui é subtraido o tempo de inicio do jogo
                tempoSt -= Time.deltaTime;
                tTempSt.text = tempoSt.ToString("0");
            }
            else
            {
                //Quando o tempo acaba dar a mensagem que vai iniciar e desativa o UI responsável pela contagem
                tTempSt.text = "GO";
                tempGO -= Time.deltaTime;
                if (tempGO < 0.2)
                {
                    canvasTP.SetActive(false);
                }
            }
        }
        //O posicionamento da câmera só ocorre caso o player não esteja no menu e o bool (ok) seja falso
        if(!ok && OndeEstou.instance.fase != 0)
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
