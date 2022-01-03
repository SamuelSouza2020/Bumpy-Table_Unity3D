using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
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
        gameCam = GameObject.Find("Main Camera").GetComponent<CamGame>();
        tTempSt = GameObject.Find("TempoStart").GetComponent<Text>();
        canvasTP = GameObject.Find("CanvasTp");

        //aud = GetComponent<AudioSource>();
        //aud2 = GetComponent<AudioSource>();
        mov = false;
    }
    void Update()
    {
        Debug.Log(rig.velocity.magnitude);
        if(gameCam.ok)
        {
            if (fora)
            {
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


                tiltX = Input.acceleration.x * sensib;
                tiltY = Input.acceleration.y * sensib;
                rig.velocity = new Vector3(tiltX, rig.velocity.y, tiltY);
            }
            else
            {
                rig.velocity = new Vector3(0, 0, 0);
                transform.position = Vector3.Lerp(transform.position, new Vector3(nPos.x, transform.position.y, nPos.z), 3 * Time.deltaTime);
                gameObject.GetComponent<Collider>().enabled = false;
                rig.velocity = new Vector3(0, -1, 0);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Buraco"))
        {
            Debug.Log("EntrouA");
            nPos = new Vector3(other.transform.position.x, transform.position.y,
                other.transform.position.z);
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z);
            fora = false;
        }
        if (other.gameObject.CompareTag("BuracoFim"))
        {
            nPos = new Vector3(other.transform.position.x, transform.position.y,
                other.transform.position.z);
            rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, rig.velocity.z);
            StartCoroutine(PerdeuGm());
            canvasTP.SetActive(true);
            tTempSt.text = "PERDEU";
            fora = false;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Parede"))
        {
            aud2.Play();
        }
    }
    IEnumerator PerdeuGm()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(0);
    }
}
