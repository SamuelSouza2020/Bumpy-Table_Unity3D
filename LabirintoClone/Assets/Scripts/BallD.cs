using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallD : MonoBehaviour
{
    //Todos os comandos são encontrados Unity Documentation
    //Esse script fica no buraco que movimenta
    [SerializeField]
    GameObject bur;

    Rigidbody rb;

    Player player;
    CamGame game;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
        game = GameObject.Find("Main Camera").GetComponent<CamGame>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rb.velocity.magnitude);
        bur.transform.position = new Vector3(gameObject.transform.position.x, bur.transform.position.y, gameObject.transform.position.z);
        //Caso a magnitude da velocidade seja menor que 7 é adicionada uma velocidade aleatória
        if(game.ok && rb.velocity.magnitude <= 7)
        {
            rb.velocity = new Vector3(Random.Range(-6,6), 0, Random.Range(-6, 6));
        }
        //Se o player já estiver em um buraco a velocidade vai para zero.
        if(!player.fora)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
