using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallD : MonoBehaviour
{
    [SerializeField]
    GameObject bur;

    Rigidbody rb;
    [SerializeField]
    Player player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        bur.transform.position = new Vector3(gameObject.transform.position.x, bur.transform.position.y, gameObject.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector3(6, 0, 6);
        }
        if(!player.fora)
        {
            rb.velocity = Vector3.zero;
        }
    }
}
