using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CherryBall : MonoBehaviour
{

    public float cherryBall;
    public GameObject ballEffect;

    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RB.velocity = new Vector2(cherryBall * transform.localScale.x, 0);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if(other.tag == "Fighter1")
        {
            FindObjectOfType<GameSystem>().TouchFighter1();
        }

        if(other.tag == "Fighter2")
        {
            FindObjectOfType<GameSystem>().TouchFighter2();
        }

        Instantiate(ballEffect, transform.position, transform.rotation);
            
        Destroy(gameObject);
    }
}
