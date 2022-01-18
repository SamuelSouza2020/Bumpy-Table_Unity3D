using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    //Todos os comandos são encontrados Unity Documentation
    Rigidbody rig;
    float tiltX, tiltY, sensib = 10;
    public bool fora = true, mov = false;
    [SerializeField]
    Vector3 nPos;
    CamGame gameCam;

    GameObject canvasTP;
    Text tTempSt;

    [SerializeField]
    AudioSource aud, aud2;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        //GameObjet.Find("Nome") é usado para encontrar o objeto com este "Nome".
        gameCam = GameObject.Find("Main Camera").GetComponent<CamGame>();
        tTempSt = GameObject.Find("TempoStart").GetComponent<Text>();
        canvasTP = GameObject.Find("CanvasTp");
        mov = false;
    }
    void Update()
    {
        //gameCam é a Camera do jogo, quando a variavel bool (ok) for verdareira o player pode se movimentar.
        if(gameCam.ok)
        {
            //Variavel bool (fora) indica que o player não caiu no buraco, caso verdadeira o player não movimenta mais a bola
            if (fora)
            {
                //Usando o velocity.magnitudo no IF para decidir o som da bola
                if (rig.velocity.magnitude > 5)
                {
                    aud.volume = 0.5f;
                    aud.pitch = 1.6f;
                }
                else if(rig.velocity.magnitude > 3 && rig.velocity.magnitude <= 5)
                {
                    aud.volume = 0.5f;
                    aud.pitch = 1.35f;
                }
                else if(rig.velocity.magnitude > 2 && rig.velocity.magnitude <= 3)
                {
                    aud.volume = 0.5f;
                    aud.pitch = 1.2f;
                }  
                else if(rig.velocity.magnitude > 1.5 && rig.velocity.magnitude <= 2)
                {
                    aud.volume = 0.4f;
                    aud.pitch = 1;
                }
                else if (rig.velocity.magnitude > 1 && rig.velocity.magnitude <= 1.5)
                {
                    aud.volume = 0.3f;
                    aud.pitch = 1;
                }
                else if (rig.velocity.magnitude > 0.7 && rig.velocity.magnitude <= 0.1)
                    aud.volume = 0.2f;
                else if (rig.velocity.magnitude > 0.3 && rig.velocity.magnitude <= 0.7)
                    aud.volume = 0.13f;
                else
                    aud.volume = 0.08f;

                //Quando a bola começa a se mover que o som inicia
                //Variável bool (mov) é utilizada para iniciar o audio uma vez.
                if (rig.velocity.magnitude >= 0.2 && !mov)
                {
                    aud.Play();
                    mov = true;
                }
                if(rig.velocity.magnitude < 0.2)
                {
                    aud.Stop();
                    mov = false;
                }

                //tiltX e tiltY é usado para dar aceleração para o player de acordo com o sensor do aparelho
                tiltX = Input.acceleration.x * sensib;
                tiltY = Input.acceleration.y * sensib;
                rig.velocity = new Vector3(tiltX, rig.velocity.y, tiltY);
            }
            else
            {
                /*
                Caso o player entre em contato com um buraco, a variavel bool (fora) vai para falso
                desativando a velocidade, collider e simula que ele está caindo no buraco
                */
                rig.velocity = new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, new Vector3(nPos.x, transform.position.y, nPos.z), 3 * Time.deltaTime);
                gameObject.GetComponent<Collider>().enabled = false;
                rig.velocity = new Vector3(0, -1, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //CompareTag("TAG") busca a tag do objeto
        if (other.gameObject.CompareTag("Buraco"))
        {
            //Quando o player cai nesse buraco ele avança de fase
            aud.Stop();
            nPos = new Vector3(other.transform.position.x, transform.position.y,
                other.transform.position.z);
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z);
            fora = false;
        }
        if (other.gameObject.CompareTag("BuracoFim"))
        {
            //Quando o player cai nesse buraco ele perde o game e volta para o menu
            aud.Stop();
            nPos = new Vector3(other.transform.position.x, transform.position.y,
                other.transform.position.z);
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z);
            StartCoroutine(PerdeuGm());
            canvasTP.SetActive(true);
            tTempSt.text = "PERDEU";
            fora = false;
        }
        if (other.gameObject.CompareTag("BuracoUlt"))
        {
            //Buraco encontrado na última fase, dizendo que finalizou o jogo
            aud.Stop();
            nPos = new Vector3(other.transform.position.x, transform.position.y,
                other.transform.position.z);
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z);
            canvasTP.SetActive(true);
            tTempSt.text = "PARABÉNS, CONCLUIU A DEMONSTRAÇÃO";
            fora = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        //Quando ele bater na parede vai iniciar um som da batida
        if (collision.gameObject.CompareTag("Parede"))
        {
            aud2.Play();
        }
    }
    IEnumerator PerdeuGm()
    {
        //Após passar 2 segundos volta para o Menu
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
