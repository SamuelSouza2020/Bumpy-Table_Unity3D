using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallD : MonoBehaviour
{
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
        if(game.ok && rb.velocity.magnitude <= 5)
        {
            rb.velocity = new Vector3(Random.Range(-6,6), 0, Random.Range(-6, 6));
        }
        /*if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(6, 0, 6);
        }*/
        if(!player.fora)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
