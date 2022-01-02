using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rig;
    float tiltX, tiltY, sensib = 5;
    public bool fora = true;
    [SerializeField]
    Vector3 nPos;
    CamGame gameCam;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        gameCam = GameObject.Find("Main Camera").GetComponent<CamGame>();
    }
    void Update()
    {
        if(gameCam.ok)
        {
            if (fora)
            {
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
    }
}
